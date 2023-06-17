using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD_Management_System
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
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
    }
}
