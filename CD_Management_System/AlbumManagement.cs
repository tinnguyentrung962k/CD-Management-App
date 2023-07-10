using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CD_Management_System
{
    public partial class AlbumManagement : Form
    {
        CDStoreContext _context = new CDStoreContext();
        CdAlbumService _albumService = new CdAlbumService();
        SongService _songService = new SongService();
        AccountService _accountService = new AccountService();
        ActivityLogService _activityLogService = new ActivityLogService();

        public static int sendAlbumID = 0;
        public static string receivedUserName = Login.sendUserName;
        public static string receivedPassword = Login.sendPassword;
        public static Account LoggedIn;

        public AlbumManagement()
        {
            LoggedIn = _accountService.GetAll().Where(x => x.UserName == receivedUserName).FirstOrDefault();
            InitializeComponent();
            var listAlbum = _albumService.GetAll().Select(p => new
            {
                p.AlbumId,
                p.AlbumName,
                p.Author,
                p.ReleaseYear,
                p.AlbumGenre,
                p.Price,
                p.Quantity,
                p.Description
            }).ToList(); ;
            dgvAlbum.DataSource = new BindingSource { DataSource = listAlbum };
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void refreshList(List<Cdalbum> list = null)
        {
            if (list != null)
            {
                dgvAlbum.DataSource = new BindingSource() { DataSource = list };
            }
            else
            {

                dgvAlbum.DataSource = _albumService.GetAll().Select(p => new
                {
                    p.AlbumId,
                    p.AlbumName,
                    p.Author,
                    p.ReleaseYear,
                    p.AlbumGenre,
                    p.Price,
                    p.Quantity,
                    p.Description
                }).ToList();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cdalbum cdAlbum = new Cdalbum();
            if (txtAlbumName.Text == "" || txtReleaseYear.Text == "" || txtAuthor.Text == "" || txtGenre.Text == "" || txtQuantity.Text == "" || txtPrice.Text == ""|| txtDescription.Text == "")
            {
                MessageBox.Show("Please fill in the blank", "Notification", MessageBoxButtons.OK);
            }
            else
            {
                if (!checkNumRegex(txtReleaseYear.Text))
                {
                    MessageBox.Show("Invalid Format Release Year", "Notification", MessageBoxButtons.OK);
                }
                if (!checkNumRegex(txtQuantity.Text)) {
                    MessageBox.Show("Invalid Format Quantity", "Notification", MessageBoxButtons.OK);
                }
                if(!checkNumRegex(txtPrice.Text))
                {
                    MessageBox.Show("Invalid Format Price", "Notification", MessageBoxButtons.OK);
                }
                else
                {
                    cdAlbum.AlbumName = txtAlbumName.Text;
                    cdAlbum.ReleaseYear = Int32.Parse(txtReleaseYear.Text);
                    cdAlbum.Author = txtAuthor.Text;
                    cdAlbum.AlbumGenre = txtGenre.Text;
                    cdAlbum.Quantity = Int32.Parse(txtQuantity.Text);
                    cdAlbum.Description = txtDescription.Text;
                    cdAlbum.Price = Double.Parse(txtPrice.Text);
                    _albumService.Create(cdAlbum);
                    ActivityLog log = new ActivityLog();
                    log.ActivityDate = DateTime.Now;
                    log.Activity = "Album Management Table (" + LoggedIn.RoleId
                        + "-" + LoggedIn.AccountId + " "
                        + LoggedIn.FullName + "): Created CdAlbum '" + cdAlbum.AlbumName + "' at "
                        + DateTime.Now.ToString("hh:mm:ss tt");
                    _activityLogService.Create(log);
                    refreshList();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this album?", "System message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var songQueue = _songService.GetAll().Where(p => p.AlbumId.Equals(Int32.Parse(txtAlbumId.Text))).ToList();
                for (int i = 0; i < songQueue.Count; i++)
                {
                    _songService.Remove(songQueue[i]);
                }
                var cdAlbum = _albumService.GetAll().Where(p => p.AlbumId.Equals(Int32.Parse(txtAlbumId.Text))).FirstOrDefault();
                if (Int32.Parse(txtAlbumId.Text).Equals(cdAlbum.AlbumId))
                {
                    ActivityLog log = new ActivityLog();
                    log.ActivityDate = DateTime.Now;
                    log.Activity = "Album Management Table (" + LoggedIn.RoleId
                        + "-" + LoggedIn.AccountId + " "
                        + LoggedIn.FullName + "): Deleted CdAlbum '" + cdAlbum.AlbumName + "' at "
                        + DateTime.Now.ToString("hh:mm:ss tt");
                    _activityLogService.Create(log);
                    _albumService.Remove(cdAlbum);
                }
                refreshList();
            }
        }

        private void dgvAlbum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            var id = dgvAlbum[0, e.RowIndex].Value;
            var cdAlbum = _albumService.GetAll().Where(p => p.AlbumId.Equals(id)).FirstOrDefault();
            txtAlbumId.Text = id.ToString();
            txtAlbumName.Text = cdAlbum.AlbumName;
            txtReleaseYear.Text = cdAlbum.ReleaseYear.ToString();
            txtAuthor.Text = cdAlbum.Author;
            txtGenre.Text = cdAlbum.AlbumGenre;
            txtQuantity.Text = cdAlbum.Quantity.ToString();
            txtDescription.Text = cdAlbum.Description;
            txtPrice.Text = cdAlbum.Price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var cdAlbum = _albumService.GetAll().Where(p => p.AlbumId.Equals(Int32.Parse(txtAlbumId.Text))).FirstOrDefault();
            if (Int32.Parse(txtAlbumId.Text).Equals(cdAlbum.AlbumId))
            {
                if (txtAlbumName.Text == "" || txtReleaseYear.Text == "" || txtAuthor.Text == "" || txtGenre.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "" || txtDescription.Text == "")
                {
                    MessageBox.Show("Please fill in the blank", "Notification", MessageBoxButtons.OK);
                }
                else
                {
                    if (!checkNumRegex(txtReleaseYear.Text))
                    {
                        MessageBox.Show("Invalid Format Release Year", "Notification", MessageBoxButtons.OK);
                    }
                    else {
                        if (!checkNumRegex(txtQuantity.Text))
                        {
                            MessageBox.Show("Invalid Format Quantity", "Notification", MessageBoxButtons.OK);
                        }
                        else {
                            if (!checkNumRegex(txtPrice.Text))
                            {
                                MessageBox.Show("Invalid Format Price", "Notification", MessageBoxButtons.OK);
                            }
                            else
                            {
                                cdAlbum.AlbumName = txtAlbumName.Text;
                                cdAlbum.ReleaseYear = Int32.Parse(txtReleaseYear.Text);
                                cdAlbum.Author = txtAuthor.Text;
                                cdAlbum.AlbumGenre = txtGenre.Text;
                                cdAlbum.Quantity = Int32.Parse(txtQuantity.Text);
                                cdAlbum.Description = txtDescription.Text;
                                cdAlbum.Price = Double.Parse(txtPrice.Text);
                                _albumService.Update(cdAlbum);
                                ActivityLog log = new ActivityLog();
                                log.ActivityDate = DateTime.Now;
                                log.Activity = "Album Management Table (" + LoggedIn.RoleId
                                 + "-" + LoggedIn.AccountId + " "
                                 + LoggedIn.FullName + "): Updated CdAlbum with ID = '" + cdAlbum.AlbumId + "' at "
                                 + DateTime.Now.ToString("hh:mm:ss tt");
                                _activityLogService.Create(log);
                                refreshList();
                            }
                        }
                    }
                }
            }

        }
        private bool checkNumRegex(string input)
        {
            var regex = new Regex("^\\d+$");
            bool valid = true;
            if (!regex.IsMatch(input))
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        private void dgvAlbum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            sendAlbumID = (int)dgvAlbum[0, e.RowIndex].Value;
            var album = _albumService.GetAll().Where(p => p.AlbumId == sendAlbumID).FirstOrDefault();
            if (album != null)
            {
                Form song = new SongManagement();
                song.Show();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAlbumId.Text = "";
            txtAlbumName.Text = "";
            txtReleaseYear.Text = "";
            txtAuthor.Text = "";
            txtGenre.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            refreshList();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchkey = txtSearchBox.Text;
            dgvAlbum.DataSource = new BindingSource()
            {
                DataSource = _albumService.GetAll().Where(p => p.AlbumName.ToLower().Contains(searchkey.ToLower()) || p.AlbumGenre.ToLower().Contains(searchkey.ToLower()) || p.Author.ToLower().Contains(searchkey.ToLower())).Select(p => new
                {
                    p.AlbumId,
                    p.AlbumName,
                    p.Author,
                    p.ReleaseYear,
                    p.AlbumGenre,
                    p.Price,
                    p.Quantity,
                    p.Description
                }).ToList()
            };
        }
    }
}