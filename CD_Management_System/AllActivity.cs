using Repository.Services;
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
    public partial class AllActivity : Form
    {
        ActivityLogService _activityLogService = new ActivityLogService();
        public AllActivity()
        {
            InitializeComponent();

            var log = _activityLogService.GetAll().Select(l => new
            {
                l.ActivityId,
                l.ActivityDate,
                l.Activity
            }).ToList();

            dgvActivityList.DataSource = new BindingSource()
            {
                DataSource = log
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
