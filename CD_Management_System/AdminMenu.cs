using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository.Models;
using Repository.Services;

namespace CD_Management_System
{
    public partial class AdminMenu : Form
    {
        CdAlbumService _cdAlbumService = new CdAlbumService();
        SongService _songService = new SongService();
        CustomerRequestService _customerRequestService = new CustomerRequestService();
        AccountService _accountService = new AccountService();
        public static Account LoggedIn;
        public AdminMenu()
        {
            LoggedIn = _accountService.GetAll().Where(x => x.UserName == Login.sendUserName).FirstOrDefault();
            InitializeComponent();
            txtTitleMng.Text = "Welcome, " + LoggedIn.FullName;
            totalAlbum.Text = "Total album: " + _cdAlbumService.GetAll().Count().ToString();
            totalSong.Text = "Total song: " + _songService.GetAll().Count().ToString();
            totalRequest.Text = "Total request: " + _customerRequestService.GetAll().Count().ToString();
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            Form em = new EmployeeManagement();
            em.ShowDialog();
        }

        private void btnAlbumManagement_Click(object sender, EventArgs e)
        {
            Form am = new AlbumManagement();
            am.ShowDialog();
        }

        private void btnRequestManagement_Click(object sender, EventArgs e)
        {
            Form rm = new Request(LoggedIn);
            rm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to log out?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Form form = new Login();
                form.Show();
            }
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            Form log = new AllActivity();
            log.ShowDialog();
        }
    }
}
