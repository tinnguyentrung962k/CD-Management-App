using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Repository.Models;
using Repository.Services;
using System.Runtime.CompilerServices;

namespace CD_Management_System
{
    public partial class SongManagement : Form
    {
        CDStoreContext _context = new CDStoreContext();
        CdAlbumService _albumService = new CdAlbumService();
        SongService _songService = new SongService();

        public int receiceAlbumID = AlbumManagement.sendAlbumID;

        public SongManagement()
        {
            InitializeComponent();
            this.ControlBox = false;
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
            song.AlbumId = album.AlbumId;
            song.SongName = txtSongName.Text;
            song.Duration = txtDuration.Text;
            _songService.Create(song);

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
                _songService.Remove(selectedSong);
            }
            else
            {
                txtLog.Text = "";
                txtLog.Text = "Wrong SongID format dude";
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
                        temp.SongName = txtSongName.Text;
                        temp.Duration = txtDuration.Text;
                        temp.AlbumId = receiceAlbumID;
                        _songService.Update(temp);
                    }
                }
                else
                {
                    txtLog.Text = "";
                    txtLog.Text = "Wrong SongID format dude";
                }
            }
            else
            {

                txtLog.Text = "";
                txtLog.Text = "You didn't choose a song dude!";
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

        //private bool validateInterger()
        //{
        //    var elements = new[] { intSongID };
        //    int temp;
        //    var valid = true;
        //    foreach (var element in elements.Where(d => int.TryParse(d.Text, out temp) == false))
        //    {
        //        txtLog.Text = txtLog.Text + "" + element.Name + "is not integer; \n";
        //        valid = false;
        //    }
        //    return valid;
        //}

        private void closeForm(object sender, EventArgs e)
        {
            AlbumManagement.sendAlbumID = 0;
            this.Close();
        }
    }
}