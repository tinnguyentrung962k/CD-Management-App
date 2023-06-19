namespace CD_Management_System
{
    partial class EmployeeManagement
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEmployee = new DataGridView();
            label1 = new Label();
            label6 = new Label();
            txtAccountId = new TextBox();
            label4 = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtAddress = new TextBox();
            label7 = new Label();
            txtPhoneNumber = new TextBox();
            Search = new Label();
            txtSearch = new TextBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            label8 = new Label();
            txtPassword = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployee
            // 
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(38, 49);
            dgvEmployee.Margin = new Padding(3, 2, 3, 2);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.RowTemplate.Height = 29;
            dgvEmployee.Size = new Size(856, 135);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellClick += chooseEmployee;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(312, 9);
            label1.Name = "label1";
            label1.Size = new Size(299, 37);
            label1.TabIndex = 1;
            label1.Text = "Employee Management";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 206);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 10;
            label6.Text = "accountID";
            // 
            // txtAccountId
            // 
            txtAccountId.Location = new Point(136, 203);
            txtAccountId.Margin = new Padding(3, 2, 3, 2);
            txtAccountId.Name = "txtAccountId";
            txtAccountId.ReadOnly = true;
            txtAccountId.Size = new Size(133, 23);
            txtAccountId.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 241);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 12;
            label4.Text = "userName";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(136, 238);
            txtUserName.Margin = new Padding(3, 2, 3, 2);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(252, 23);
            txtUserName.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 325);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 14;
            label2.Text = "fullName";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(136, 325);
            txtFullName.Margin = new Padding(3, 2, 3, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(252, 23);
            txtFullName.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 371);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 16;
            label3.Text = "email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(136, 371);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(252, 23);
            txtEmail.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 410);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 18;
            label5.Text = "address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(136, 410);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(252, 23);
            txtAddress.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 446);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 20;
            label7.Text = "phoneNumber";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(136, 446);
            txtPhoneNumber.Margin = new Padding(3, 2, 3, 2);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(252, 23);
            txtPhoneNumber.TabIndex = 21;
            // 
            // Search
            // 
            Search.AutoSize = true;
            Search.Location = new Point(434, 241);
            Search.Name = "Search";
            Search.Size = new Size(97, 15);
            Search.TabIndex = 22;
            Search.Text = "Search Employee";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(537, 238);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(212, 23);
            txtSearch.TabIndex = 23;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(487, 402);
            btnCreate.Margin = new Padding(3, 2, 3, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(141, 36);
            btnCreate.TabIndex = 24;
            btnCreate.Text = "Create Employee";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(487, 325);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(143, 36);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update Employee";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(697, 325);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 36);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete Employee";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(772, 234);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(122, 28);
            btnSearch.TabIndex = 27;
            btnSearch.Text = "Search Employee";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 279);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 28;
            label8.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(136, 279);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(252, 23);
            txtPassword.TabIndex = 29;
            // 
            // button1
            // 
            button1.Location = new Point(697, 402);
            button1.Name = "button1";
            button1.Size = new Size(132, 36);
            button1.TabIndex = 30;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            // 
            // EmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 490);
            Controls.Add(button1);
            Controls.Add(txtPassword);
            Controls.Add(label8);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(txtSearch);
            Controls.Add(Search);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label7);
            Controls.Add(txtAddress);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtFullName);
            Controls.Add(label2);
            Controls.Add(txtUserName);
            Controls.Add(label4);
            Controls.Add(txtAccountId);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(dgvEmployee);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeeManagement";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployee;
        private Label label1;
        private Label label6;
        private TextBox txtAccountId;
        private Label label4;
        private TextBox txtUserName;
        private Label label2;
        private TextBox txtFullName;
        private Label label3;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtAddress;
        private Label label7;
        private TextBox txtPhoneNumber;
        private Label Search;
        private TextBox txtSearch;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private Label label8;
        private TextBox txtPassword;
        private Button button1;
    }
}