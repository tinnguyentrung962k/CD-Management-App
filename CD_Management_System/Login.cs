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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CD_Management_System
{
    public partial class Login : Form
    {
        AccountService _userServices = new AccountService();
        CDStoreContext _storeContext = new CDStoreContext();
        public static String sendUserName = "";
        public static String sendPassword = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password");
            }
            else if (IsValidUser())
            {
                var user = _userServices.GetAll().Where(p => p.UserName == txtUsername.Text && p.PassWord == txtPassword.Text).FirstOrDefault();
                sendUserName = txtUsername.Text;
                sendPassword = txtPassword.Text;
                if (user.RoleId == "MG")
                {
                    this.Hide();
                    Form mngMenu = new AdminMenu();
                    mngMenu.ShowDialog();
                }
                else
                {
                    this.Hide();
                    Form empMenu = new EmployeeMenu();
                    empMenu.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Error. Invalid given info");
            }
        }

        public bool IsValidUser()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var user = _userServices.GetAll().Where(p => p.UserName == username && p.PassWord == password).FirstOrDefault();
            if (user != null)
            {

                return true;

            }
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

    }
}
