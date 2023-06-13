using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Repository.Models;
using Repository.Services;

namespace CD_Management_System
{
    public partial class SongManagement : Form
    {
        CDStoreContext _context = new CDStoreContext();
        CdAlbumService _albumService = new CdAlbumService();
        SongService _songService = new SongService();
        public SongManagement()
        {
            InitializeComponent();

            var albumList = _albumService.GetAll().Select(p => new
                {
                    p.AlbumId,
                    p.AlbumName,
                    p.ReleaseYear,
                    p.Author,
                    p.AlbumGenre,
                    p.Price,
                    p.Quantity
                }).ToList();

            dgvAlbumList.DataSource = new BindingSource()
            {
                DataSource = albumList
            };
        }

        private void getSongList(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvAlbumList[0, e.RowIndex].Value;
            var temp = _albumService.GetAll().Where(p => p.AlbumId.Equals(id)).FirstOrDefault();
            if (temp != null)
            {
                intAlbumID.Text = temp.AlbumId.ToString();
                txtAlbumName.Text = temp.AlbumName;
                intReleaseYear.Text = temp.ReleaseYear.ToString();
                txtAuthor.Text = temp.Author;
                txtAlbumGerne.Text = temp.AlbumGenre;
                dblPrice.Text = temp.Price.ToString();
                intQuantity.Text = temp.Quantity.ToString();
                txtDescription.Text = temp.Description;
            }
            var listAlbum = _albumService.GetAll()
                .Select(p => new { p.AlbumId, p.AlbumName })
                .ToList();
            var songList = _songService.GetAll().Where(p => p.AlbumId.Equals(id))
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
                    int id = Int32.Parse(intAlbumID.Text);
                    if (validateNull() && validateInterger() && validateDouble())
                    {
                        createSong(_albumService.GetAll().Where(p => p.AlbumId.Equals(id)).FirstOrDefault());
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
                    reloadAlbum();
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

        private Cdalbum createAlbum()
        {
            var cdAlbum = new Cdalbum();
            cdAlbum.AlbumName = txtAlbumName.Text;
            cdAlbum.ReleaseYear = Int32.Parse(intReleaseYear.Text);
            cdAlbum.Author = txtAuthor.Text;
            cdAlbum.AlbumGenre = txtAlbumGerne.Text;
            cdAlbum.Price = Double.Parse(dblPrice.Text);
            cdAlbum.Quantity = Int32.Parse(intQuantity.Text);
            cdAlbum.Description = txtDescription.Text;
            _albumService.Create(cdAlbum);
            return cdAlbum;
        }

        private void createSong(Cdalbum album)
        {
            var song = new Song();
            song.AlbumId = album.AlbumId;
            song.SongName = txtSongName.Text;
            song.Duration = txtDuration.Text;
            _songService.Create(song);

        }

        public void reloadAlbum()
        {
            var albumList = _albumService.GetAll()
                .Select(p => new
                {
                    p.AlbumId,
                    p.AlbumName,
                    p.ReleaseYear,
                    p.Author,
                    p.AlbumGenre,
                    p.Price,
                    p.Quantity
                }).ToList();

            dgvAlbumList.DataSource = new BindingSource()
            {
                DataSource = albumList
            };

        }

        private void reloadSong()
        {
            var listAlbum = _albumService.GetAll()
                .Select(p => new { p.AlbumId, p.AlbumName })
                .ToList();
            var songList = _songService.GetAll().Where(p => p.AlbumId.Equals(Int32.Parse(intAlbumID.Text)))
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
            if (!string.IsNullOrEmpty(intAlbumID.Text))
            {
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
            else
            {
                txtLog.Text = "";
                txtLog.Text = "You didn't choose a song dude!";
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
            txtAlbumGerne.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtSongName.Text = string.Empty;
            txtAlbumName.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtDescription.Text = string.Empty;
            intAlbumID.Text = string.Empty;
            intQuantity.Text = string.Empty;
            intSongID.Text = string.Empty;
            intReleaseYear.Text = string.Empty;
            dblPrice.Text = string.Empty;
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
                        temp.AlbumId = Int32.Parse(intAlbumID.Text);
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
            var elements = new[] { txtAlbumName, txtAlbumGerne, txtAuthor, txtDuration, txtSongName, intAlbumID, intQuantity, intReleaseYear, dblPrice };
            bool valid = true;
            foreach (var element in elements.Where(d => string.IsNullOrEmpty(d.Text)))
            {
                txtLog.Text = txtLog.Text + "" + element.Name + "is empty; \n";
                valid = false;
            }
            return valid;
        }

        private bool validateInterger()
        {
            var elements = new[] { intQuantity, intReleaseYear };
            int temp;
            var valid = true;
            foreach (var element in elements.Where(d => int.TryParse(d.Text, out temp) == false))
            {
                txtLog.Text = txtLog.Text + "" + element.Name + "is not integer; \n";
                valid = false;
            }
            return valid;
        }

        private bool validateDouble()
        {
            var elements = new[] { dblPrice };
            double temp;
            var valid = true;
            foreach (var element in elements.Where(d => Double.TryParse(d.Text, out temp) == false))
            {
                txtLog.Text = txtLog.Text + "" + element.Name + "is not double; \n";
                valid = false;
            }
            return valid;
        }
    }
}