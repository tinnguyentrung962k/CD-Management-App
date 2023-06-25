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
    public partial class EmployeeManagement : Form
    {
        CDStoreContext _context = new CDStoreContext();
        List<Account> listEmployee = new List<Account>();
        AccountService _accountService;
        public EmployeeManagement()
        {
            InitializeComponent();
            getAllEmployees();

        }
        private void getAllEmployees()
        {
            _accountService = new AccountService();
            var listEmployee = _accountService.GetAll().Include(p => p.Role).Select(p => new
            {
                p.AccountId,
                p.UserName,
                p.FullName,
                p.Role.RoleName,
                p.Email,
                p.Address,
                p.PhoneNumber
            }).ToList();
            dgvEmployee.DataSource = new BindingSource()
            {
                DataSource = listEmployee
            };

        }

        private void chooseEmployee(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvEmployee[0, e.RowIndex].Value;
            var selectedEmployee = _accountService.GetAll()
                .Where(p => p.AccountId.Equals(id))
                .FirstOrDefault();
            if (selectedEmployee != null)
            {
                txtAccountId.Text = selectedEmployee.AccountId.ToString();
                txtUserName.Text = selectedEmployee.UserName;
                txtFullName.Text = selectedEmployee.FullName;
                txtEmail.Text = selectedEmployee.Email;
                txtAddress.Text = selectedEmployee.Address;
                txtPhoneNumber.Text = selectedEmployee.PhoneNumber;

            }
        }

        private void btnCreate_click(object sender, EventArgs e)
        {
            Account account = new Account();
            if (txtUserName.Text == "" || txtFullName.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtPhoneNumber.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in the blank", "Notification", MessageBoxButtons.OK);
            }
            else if (!emailRegex(txtEmail.Text))
            {
                MessageBox.Show("Invalid Format for email", "Notification", MessageBoxButtons.OK);
            }
            else if (!phoneNumberRegex(txtPhoneNumber.Text))
            {
                MessageBox.Show("Invalid Format for Phone Number", "Notification", MessageBoxButtons.OK);
            }
            else
            {
                account.UserName = txtUserName.Text;
                account.FullName = txtFullName.Text;
                account.Email = txtEmail.Text;
                account.Address = txtAddress.Text;
                account.PhoneNumber = txtPhoneNumber.Text;
                account.PassWord = txtPassword.Text;
                account.RoleId = "EM";
                _accountService.Create(account);
                refreshList();
            }

        }


        private bool phoneNumberRegex(string phoneNumber)
        {
            var regex = new Regex("^\\(?([0]{1})\\)?[-. ]?([0-9]{9})$");
            bool valid = true;
            if (!regex.IsMatch(phoneNumber))
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        private bool emailRegex(string email)
        {
            var regex = new Regex("^\\S+@\\S+\\.\\S+$");
            bool valid = true;
            if (!regex.IsMatch(email))
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public void refreshList(List<Account> list = null)
        {
            if (list != null)
            {
                dgvEmployee.DataSource = new BindingSource()
                {
                    DataSource = list
                };
            }
            else
            {

                dgvEmployee.DataSource = _accountService.GetAll().Select(p => new
                {
                    p.AccountId,
                    p.UserName,
                    p.FullName,
                    p.Role.RoleName,
                    p.Email,
                    p.Address,
                    p.PhoneNumber
                }).ToList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var employee = _accountService.GetAll().Where(p => p.AccountId.Equals(Int32.Parse(txtAccountId.Text))).FirstOrDefault();
            if (Int32.Parse(txtAccountId.Text).Equals(employee.AccountId))
            {
                if (txtUserName.Text == "" || txtFullName.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtPhoneNumber.Text == "")
                {
                    MessageBox.Show("Please fill the blank", "Notification", MessageBoxButtons.OK);
                }
                else if (!emailRegex(txtEmail.Text))
                {
                    MessageBox.Show("Invalid Format for email", "Notification", MessageBoxButtons.OK);
                }
                else if (!phoneNumberRegex(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Invalid Format for Phone Number", "Notification", MessageBoxButtons.OK);
                }
                else
                {
                    employee.UserName = txtUserName.Text;
                    employee.FullName = txtFullName.Text;
                    employee.Email = txtEmail.Text;
                    employee.Address = txtAddress.Text;
                    employee.PhoneNumber = txtPhoneNumber.Text;
                    _accountService.Update(employee);
                    refreshList();
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var employee = _accountService.GetAll().Where(p => p.AccountId.Equals(Int32.Parse(txtAccountId.Text))).FirstOrDefault();
            if (Int32.Parse(txtAccountId.Text).Equals(employee.AccountId))
                _accountService.Remove(employee);
            refreshList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchkey = txtSearch.Text;
            dgvEmployee.DataSource = new BindingSource()
            {
                DataSource = _accountService.GetAll().Where(p => p.UserName.ToLower().Contains(searchkey.ToLower()) || p.FullName.ToLower().Contains(searchkey.ToLower()) || p.PhoneNumber.Contains(searchkey.ToLower())).Select(p => new
                {
                    p.AccountId,
                    p.UserName,
                    p.FullName,
                    p.Role.RoleName,
                    p.Email,
                    p.Address,
                    p.PhoneNumber
                }).ToList()
            };

        }
    }
}
