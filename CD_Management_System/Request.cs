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
        private CustomerRequestService crr;
        private CustomerRequest? req;
        private bool addMode = false;
        private bool isAsc = true;
        private string filter = "RequestId";
        private string searchKey = "";
        private int rowIndex = -1;
        public Request()
        {
            user = new AccountService().GetAll().FirstOrDefault(p => p.UserName.Equals(Login.sendUserName) && p.PassWord.Equals(Login.sendPassword));
            if (user is null){
                MessageBox.Show("You're not allowed to use this, please log in.", "Unable to authorize");
                return;
            }
            else
            {
                InitializeComponent();
                crr = new CustomerRequestService();
                initializeReq();
                updateDvg();
                this.user = user;
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
            addMode = !addMode;
            addEnable(addMode);
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtDescription.Text = "";
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateReq();
        }

        // Create,update,remove request
        private void updateReq()
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("You haven't selected any request!", "No request selected");
            }
            else
            {
                req.CustomerName = txtName.Text;
                req.PhoneNumber = txtPhone.Text;
                req.Email = txtEmail.Text;
                req.Description = txtDescription.Text;
                try
                {
                    crr.Update(req);
                    addToLog("update");
                    initializeReq();
                    getReq();
                    updateDvg();
                    rowIndex = -1;
                    MessageBox.Show("Request processed!", "Update done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't update request due to:\n" + ex.ToString(), "Update failed");
                }
            }
        }
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
            if (crr.Remove(req))
            {
                MessageBox.Show("Request removed successfully!", "Removal done");
                addToLog("remove");
                initializeReq();
                getReq();
                updateDvg();
                rowIndex = -1;
                return;
            }
            else MessageBox.Show("Unable to remove request!", "Removal failed");
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
                rowIndex = -1;
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

        //Component_handler
        private void requestDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            rowIndex = e.RowIndex;
            string? requestId = requestDgv.Rows[rowIndex].Cells[0].Value.ToString();
            req = crr.GetAll().ToList().FirstOrDefault(p => p.RequestId.ToString() == requestId);
            getReq();
            addMode = false;
            setBtnEnable(true);
        }

        private void always_handled(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int count = txtDescription.Text.Count();
            textCount.Text = "Count: " + count;

        }

        //Tools
        private void addEnable(bool enable)
        {
            setBtnEnable(!enable);
            if (enable)
            {
                txtName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtDescription.Text = "";
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
            if (addMode)
            {
                updateBtn.Enabled = false;
                acceptBtn.Enabled = false;
                denyBtn.Enabled = false;
                removeBtn.Enabled = false;
            }
            else
            {
                updateBtn.Enabled = enable;
                acceptBtn.Enabled = enable;
                denyBtn.Enabled = enable;
                removeBtn.Enabled = enable;
            }
            addBtn.Text = addMode ? "Cancel Request" : "Add Request";
            clearBtn.Enabled = !enable;
            confirmBtn.Enabled = !enable;
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

        private void initializeReq()
        {
            req = new CustomerRequest();
            req.CustomerName = "";
            req.PhoneNumber = "";
            req.Email = "";
            req.Description = "";
            req.Status = "";
        }

        private bool verify()
        {
            string text = "";
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (txtName.Text == "")
            {
                text += "Name can't be empty.\n";
            }
            else if (txtPhone.Text == "")
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

        private void addToLog(string action)
        {
            ActivityLogService alr = new ActivityLogService();
            string s = "Customer Request table: personnel " + user.FullName +"("+ user.RoleId + "-" + user.AccountId + ") " + action + "s ";
            switch (action)
            {
                case "create":
                    {
                        s += "a new request";
                        break;
                    }
                default:
                    {
                        s += "a request";
                        break;
                    }
            }
            s += " with id: " + req.RequestId;
            s += " at " + DateTime.Now.ToString("hh:mm:ss tt");
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
    }
}
