using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Repository.Models;
using Repository.Services;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CD_Management_System
{
    public partial class SongManagement : Form
    {
        CDStoreContext _context = new CDStoreContext();
        CdAlbumService _albumService = new CdAlbumService();
        SongService _songService = new SongService();
        AccountService _accountService = new AccountService();
        ActivityLogService _activityLogService = new ActivityLogService();

        public int receiceAlbumID = AlbumManagement.sendAlbumID;
        public static string receivedUserName = Login.sendUserName;
        public static string receivedPassword = Login.sendPassword;
        public static Account LoggedIn = AlbumManagement.LoggedIn;

        public SongManagement()
        {
            InitializeComponent();
            this.ControlBox = false;
            txtLog.Text = "This is for showing status, " + LoggedIn.FullName + ".";
            getSongList();
        }

        private void getSongList()
        {
            var listAlbum = _albumService.GetAll()
                .Select(p => new { p.AlbumId, p.AlbumName })
                .ToList();
            var songList = _songService.GetAll().Where(p => p.AlbumId.Equals(receiceAlbumID))
                .Include(p => p.Album)
                .Select(p => new
                {
                    p.SongId,
                    p.SongName,
                    p.Duration,
                    p.Album.AlbumName
                }).ToList();

            dgvSongList.DataSource = new BindingSource()
            {
                DataSource = songList
            };
        }

        private void operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string op = button.Text;

            switch (op)
            {
                case "Create":
                    if (validateNull())
                    {
                        createSong(_albumService.GetAll().Where(p => p.AlbumId.Equals(receiceAlbumID)).FirstOrDefault());
                    }
                    reloadSong();
                    break;
                case "Update":
                    updateSong();
                    if (dgvSongList.Rows.Count != 0)
                    {
                        reloadSong();
                    }
                    break;
                case "Delete":
                    deleteSong();
                    if (dgvSongList.Rows.Count != 0)
                    {
                        reloadSong();
                    }
                    clearForm();
                    break;
                case "Cancel":
                    clearForm();
                    break;
                default:
                    MessageBox.Show("Something's wrong, try again", "System message", MessageBoxButtons.OK);
                    break;
            }
        }

        private void createSong(Cdalbum album)
        {
            var song = new Song();

            if (!checkRegex(txtDuration.Text))
            {
                txtLog.Text = "Invalid Format Time";
            }
            else
            {
                song.AlbumId = album.AlbumId;
                song.SongName = txtSongName.Text;
                song.Duration = txtDuration.Text;
                _songService.Create(song);
                txtLog.Text = "";
                txtLog.Text = "Added Successfully!";
                ActivityLog log = new ActivityLog();
                log.ActivityDate = DateTime.Now;
                log.Activity = "Song Management Table (" + LoggedIn.RoleId
                        + "-" + LoggedIn.AccountId + " "
                        + LoggedIn.FullName + "): Added Song '"
                        + song.SongName + "' to CdAlbum '"
                        + album.AlbumName + "' at "
                        + DateTime.Now.ToString("hh:mm:ss tt");
                _activityLogService.Create(log);
            }


        }

        private void reloadSong()
        {
            var listAlbum = _albumService.GetAll()
                .Select(p => new { p.AlbumId, p.AlbumName })
                .ToList();
            var songList = _songService.GetAll().Where(p => p.AlbumId.Equals(receiceAlbumID))
                .Include(p => p.Album)
                .Select(p => new
                {
                    p.SongId,
                    p.SongName,
                    p.Duration,
                    p.Album.AlbumName
                }).ToList();

            dgvSongList.DataSource = new BindingSource()
            {
                DataSource = songList
            };
        }

        public void deleteSong()
        {
            int id;

            bool test = Int32.TryParse(intSongID.Text, out id);
            if (test)
            {
                var selectedSong = _songService.GetAll()
                                .Where(p => p.SongId.Equals(id)).FirstOrDefault();
                ActivityLog log = new ActivityLog();
                log.ActivityDate = DateTime.Now;
                log.Activity = "Song Management Table (" + LoggedIn.RoleId
                        + "-" + LoggedIn.AccountId + " "
                        + LoggedIn.FullName + "): Deleted Song '"
                        + selectedSong.SongName + "' from CdAlbum '"
                        + _albumService.GetAll().Where(a => a.AlbumId == receiceAlbumID).FirstOrDefault().AlbumName
                        + "' at " + DateTime.Now.ToString("hh:mm:ss tt");
                _activityLogService.Create(log);
                _songService.Remove(selectedSong);
                txtLog.Text = "";
                txtLog.Text = "Deleted Successfully!";
            }
            else
            {
                txtLog.Text = "";
                txtLog.Text = "Wrong SongID Format";
            }
        }

        private void chooseSong(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvSongList[0, e.RowIndex].Value;
            var selectedSong = _songService.GetAll()
                .Where(p => p.SongId.Equals(id))
                .FirstOrDefault();
            if (selectedSong != null)
            {
                intSongID.Text = selectedSong.SongId.ToString();
                txtSongName.Text = selectedSong.SongName;
                txtDuration.Text = selectedSong.Duration;
            }
        }

        private void clearForm()
        {
            txtDuration.Text = string.Empty;
            txtSongName.Text = string.Empty;
            intSongID.Text = string.Empty;
        }

        private void updateSong()
        {
            int id;
            if (!string.IsNullOrEmpty(intSongID.Text))
            {
                bool test = int.TryParse(intSongID.Text, out id);
                if (test)
                {
                    var temp = _songService.GetAll().Where(p => p.SongId.Equals(id)).FirstOrDefault();
                    if (temp != null && validateNull())
                    {
                        if (!checkRegex(txtDuration.Text))
                        {
                            txtLog.Text = "Invalid Format Time, please following this format (mm:ss)";
                        }
                        else
                        {
                            temp.SongName = txtSongName.Text;
                            temp.Duration = txtDuration.Text;
                            temp.AlbumId = receiceAlbumID;
                            txtLog.Text = "";
                            txtLog.Text = "Updated Successfully!";
                            _songService.Update(temp);
                            ActivityLog log = new ActivityLog();
                            log.ActivityDate = DateTime.Now;
                            log.Activity = "Song Management Table (" + LoggedIn.RoleId
                                + "-" + LoggedIn.AccountId + " "
                                + LoggedIn.FullName + "): Updated Song with ID = '"
                                + temp.SongId + "' in CdAlbum '"
                                + _albumService.GetAll().Where(a => a.AlbumId == receiceAlbumID).FirstOrDefault().AlbumName 
                                + "' at " + DateTime.Now.ToString("hh:mm:ss tt");
                            _activityLogService.Create(log);
                        }
                    }
                }
                else
                {
                    txtLog.Text = "";
                    txtLog.Text = "Wrong SongID Format!";
                }
            }
            else
            {

                txtLog.Text = "";
                txtLog.Text = "No Song Was Chosen!";
            }
        }

        private bool validateNull()
        {
            var elements = new[] { txtSongName, txtDuration };
            bool valid = true;
            foreach (var element in elements.Where(d => string.IsNullOrEmpty(d.Text)))
            {
                txtLog.Text = txtLog.Text + "" + element.Name + "is empty; \n";
                valid = false;
            }
            return valid;
        }
        private bool checkRegex(string s)
        {
            bool valid = true;
            var regex = @"^[0-5][0-9]:[0-5][0-9]$";
            var format = new Regex(regex);
            if (!format.IsMatch(s))
            {
                valid = false;
            }
            return valid;
        }

        private void closeForm(object sender, EventArgs e)
        {
            AlbumManagement.sendAlbumID = 0;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSongList.DataSource = new BindingSource()
            {
                DataSource = _songService.GetAll().Where(p => p.SongName.Contains(txtSearch.Text) && p.AlbumId.Equals(receiceAlbumID)).Select(p => new
                {
                    p.SongId,
                    p.SongName,
                    p.Duration,
                    p.Album.AlbumName
                }).ToList()
            };
        }
    }
}