using Repository.Models;
using Repository.Services;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CD_Management_System
{
    public partial class Request : Form
    {
        private Account user;
        static Request f;
        private CustomerRequestService crr;
        private CustomerRequest? req;
        private bool editMode;
        private bool isAsc = true;
        private string filter = "RequestId";
        private string searchKey = "";
        public Request()
        {
            InitializeComponent();
            crr = new CustomerRequestService();
            initializeReq();
            updateDvg();

            // change later
            user = new Account();
            user.AccountId = 1;
            user.FullName = "Phạm Quang Thái";
            user.RoleId = "EM";
            searchBox.DataSource = new List<string> {
                "RequestId",
                "CustomerName",
                "PhoneNumber",
                "Email",
                "Description",
                "Status",
                "SubmitDate"
            };
        }

        // components
        private void order_Click(object sender, EventArgs e)
        {

            if (isAsc)
            {
                isAsc = false;
                order.Text = "v";
            }
            else
            {
                isAsc = true;
                order.Text = "^";
            }
            updateDvg();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            setStatus(true);
        }

        private void denyBtn_Click(object sender, EventArgs e)
        {
            setStatus(false);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            editEnable(true);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            editEnable(false);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            removeReq();
        }

        private void clearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            searchBox.SelectedIndex = 0;
            searchKey = "";
            updateDvg();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            addReq();
        }
        private void checkBtn_Click(object sender, EventArgs e)
        {
            verify();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtDescription.Text = "";
        }
        // functions
        private void addReq()
        {
            if (verify()) return;
            CustomerRequest cr = new CustomerRequest();
            cr.CustomerName = txtName.Text;
            cr.PhoneNumber = txtPhone.Text;
            cr.Email = txtEmail.Text;
            cr.Status = txtStatus.Text;
            cr.Description = txtDescription.Text;
            cr.SubmitDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            try
            {
                crr.Create(cr);
                req = crr.GetAll().ToList().Last();
                debug();
                addToLog("create");
                updateDvg();
                getReq();
                MessageBox.Show("Request created!", "Create Request done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Create Request failed");
            }
        }
        private void removeReq()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You haven't selected any request!", "No request selected");
                return;
            }
            if (txtName.Text != user.FullName + "-" + user.RoleId + "-" + user.AccountId)
            {
                MessageBox.Show("You can't remove other's request!", "No permission");
                return;
            }
            if (crr.Remove(req))
            {
                MessageBox.Show("Request removed successfully!", "Removal done");
                addToLog("remove");
                initializeReq();
                getReq();
                updateDvg();
                return;
            }
            else MessageBox.Show("Unable to remove request!", "Removal failed");
        }
        private void initializeReq()
        {
            req = new CustomerRequest();
            req.CustomerName = "";
            req.PhoneNumber = "";
            req.Email = "";
            req.Description = "";
            req.Status = "";
        }
        private void editEnable(bool enable)
        {
            editMode = enable;
            setBtnEnable(!enable);
            if (enable)
            {
                txtName.Text = user.FullName + "-" + user.RoleId + "-" + user.AccountId;
                txtPhone.Text = "";
                txtPhone.PlaceholderText = "Enter your phone number here";
                txtEmail.Text = "";
                txtEmail.PlaceholderText = "Enter your email here";
                txtDescription.Text = "";
                txtDescription.PlaceholderText = "Enter your description here";
                txtStatus.Text = "Pending";
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                getReq();
            }
        }

        private void setBtnEnable(bool enable)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                acceptBtn.Enabled = false;
                denyBtn.Enabled = false;
                removeBtn.Enabled = false;
            }
            else
            {
                acceptBtn.Enabled = enable;
                denyBtn.Enabled = enable;
                removeBtn.Enabled = enable;
            }
            addBtn.Visible = enable;
            cancelBtn.Visible = !enable;
            checkBtn.Enabled = !enable;
            clearBtn.Enabled = !enable;
            confirmBtn.Enabled = !enable;
        }

        private void setStatus(bool b)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You haven't selected any request!", "No request selected");
                return;
            }
            else if (req.Status != "Pending")
            {
                MessageBox.Show("Request has already been processed!", "Request already done");
                return;
            }
            try
            {
                if (b) txtStatus.Text = "Accepted";
                else txtStatus.Text = "Denied";
                req.Status = txtStatus.Text;
                crr.Update(req);
                addToLog(b ? "accept" : "denie");
                initializeReq();
                getReq();
                updateDvg();
                MessageBox.Show("Request processed!", "Update done");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Update failed");
            }
        }

        private void getReq()
        {
            txtName.Text = req.CustomerName;
            txtPhone.Text = req.PhoneNumber;
            txtEmail.Text = req.Email;
            txtDescription.Text = req.Description;
            txtStatus.Text = req.Status;
            txtDate.Text = req.SubmitDate.ToString("dd/MM/yyyy");
        }

        public void updateDvg()
        {
            var list = crr.GetAll().Select(p => new { p.RequestId, p.CustomerName, p.PhoneNumber, p.Email, p.Description, p.Status, p.SubmitDate });
            switch (filter)
            {
                case "RequestId":
                    {
                        if (isAsc) list = list.OrderBy(p => p.RequestId);
                        else list = list.OrderByDescending(p => p.RequestId);
                        break;
                    }
                case "CustomerName":
                    {
                        if (isAsc) list = list.OrderBy(p => p.CustomerName);
                        else list = list.OrderByDescending(p => p.CustomerName);
                        break;
                    }
                case "PhoneNumber":
                    {
                        if (isAsc) list = list.OrderBy(p => p.PhoneNumber);
                        else list = list.OrderByDescending(p => p.PhoneNumber);
                        break;
                    }
                case "Email":
                    {
                        if (isAsc) list = list.OrderBy(p => p.Email);
                        else list = list.OrderByDescending(p => p.Email);
                        break;
                    }
                case "Description":
                    {
                        if (isAsc) list = list.OrderBy(p => p.Description);
                        else list = list.OrderByDescending(p => p.Description);
                        break;
                    }
                case "Status":
                    {
                        if (isAsc) list = list.OrderBy(p => p.Status);
                        else list = list.OrderByDescending(p => p.Status);
                        break;
                    }
                case "SubmitDate":
                    {
                        if (isAsc) list = list.OrderBy(p => p.SubmitDate);
                        else list = list.OrderByDescending(p => p.SubmitDate);
                        break;
                    }
            }
            if (string.IsNullOrEmpty(searchKey))
                requestDgv.DataSource = list.ToList();
            else
            {

                requestDgv.DataSource = list.Where(p => p.CustomerName.ToLower().Contains(searchKey.ToLower())).ToList();
            }
        }

        private void requestDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            string? requestId = requestDgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            req = crr.GetAll().ToList().FirstOrDefault(p => p.RequestId.ToString() == requestId);

            getReq();
            setBtnEnable(true);
        }

        private void always_handled(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void event_handled(object sender, KeyPressEventArgs e)
        {
            if (!editMode)
            {
                e.Handled = true;
            }
        }


        private void searchIndexChanged(object sender, EventArgs e)
        {
            filter = searchBox.SelectedValue.ToString();
        }

        private void searchText(object sender, EventArgs e)
        {
            searchKey = txtSearch.Text;
            updateDvg();
        }

        private bool verify()
        {
            string text = "";
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (txtPhone.Text == "")
            {
                text += "Phone number can't be empty.\n";
            }
            else if (!(txtPhone.Text.Count() == 9 || txtPhone.Text.Count() == 11))
            {
                text += "Phone number isn't in right format.\n";
            }
            if (txtEmail.Text == "")
            {
                text += "Email can't be empty.\n";
            }
            else if (!r.IsMatch(txtEmail.Text))
            {
                text += "Email isn't in right format.\n";
            }
            if (txtDescription.Text == "")
            {
                text += "Description can't be empty.\n";
            }
            else if (txtDescription.Text.Count() > 4000)
            {
                text += "Description must be smaller than 4000 letters.\n";
            }
            if (String.IsNullOrEmpty(text))
            {
                return false;
            }
            MessageBox.Show(text, "Adding request unsuccessfully!");
            return true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int count = txtDescription.Text.Count();
            textCount.Text = "Count: " + count;

        }

        private void addToLog(string action)
        {
            ActivityLogService alr = new ActivityLogService();
            string s = "Customer Request table: (" + user.RoleId + "-" + user.AccountId + " " + user.FullName + ") " + action + "s ";
            switch (action)
            {
                case "create":
                    {
                        s += "new request( ";
                        break;
                    }
                default:
                    {
                        s += "a request( ";
                        break;
                    }
            }
            s += "id: " + req.RequestId + ", name: " + req.CustomerName + ") ";
            s += "at " + DateTime.Now.ToString("hh:mm:ss tt");
            ActivityLog al = new ActivityLog();
            al.ActivityDate = DateTime.Now;
            al.Activity = s;
            try
            {
                alr.Create(al);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "can't upload to activitylog");
            }
        }
        private void debug()
        {
            string s = "";
            s += req.RequestId + "\n";
            s += req.CustomerName + "\n";
            s += req.PhoneNumber + "\n";
            s += req.Email + "\n";
            s += req.Description + "\n";
            s += req.Status + "\n";
            s += req.SubmitDate.ToString() + "\n";
            MessageBox.Show(s);
        }
    }
}
