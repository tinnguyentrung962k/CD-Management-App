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
        public static int sendAlbumID = 0;
        public AlbumManagement()
        {
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
                p.Description,
                p.ImgSrc
            }).ToList(); ;
            dgvAlbum.DataSource = new BindingSource { DataSource = listAlbum };
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
                    p.Description,
                    p.ImgSrc
                }).ToList();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cdalbum cdAlbum = new Cdalbum();
            if (txtAlbumName.Text == "" || txtReleaseYear.Text == "" || txtAuthor.Text == "" || txtGenre.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Khong the de trong o nhap", "Thong bao", MessageBoxButtons.OK);
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
                refreshList();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var cdAlbum = _albumService.GetAll().Where(p => p.AlbumId.Equals(Int32.Parse(txtAlbumId.Text))).FirstOrDefault();
            if (Int32.Parse(txtAlbumId.Text).Equals(cdAlbum.AlbumId))
                _albumService.Remove(cdAlbum);
            refreshList();

        }

        private void dgvAlbum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                if (txtAlbumName.Text == "" || txtReleaseYear.Text == "" || txtAuthor.Text == "" || txtGenre.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Khong the de trong o nhap", "Thong bao", MessageBoxButtons.OK);
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
                    refreshList();
                }
            }

        }

        private void dgvAlbum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sendAlbumID = (int)dgvAlbum[0, e.RowIndex].Value;
            var album = _albumService.GetAll().Where(p => p.AlbumId == sendAlbumID).FirstOrDefault();
            if (album != null)
            {
                Form song = new SongManagement();
                song.Show();
            }
        }
    }
}