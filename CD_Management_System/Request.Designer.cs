namespace CD_Management_System
{
    partial class Request
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            requestDgv = new DataGridView();
            name = new Label();
            email = new Label();
            phoneNumber = new Label();
            description = new Label();
            status = new Label();
            submitDate = new Label();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtDescription = new TextBox();
            acceptBtn = new Button();
            denyBtn = new Button();
            removeBtn = new Button();
            backBtn = new Button();
            addBtn = new Button();
            txtSearch = new TextBox();
            searchList = new Label();
            txtDate = new TextBox();
            txtStatus = new TextBox();
            clearSearch = new Button();
            order = new Label();
            searchBox = new ComboBox();
            search = new Label();
            cancelBtn = new Button();
            confirmBtn = new Button();
            checkBtn = new Button();
            clearBtn = new Button();
            textCount = new Label();
            ((System.ComponentModel.ISupportInitialize)requestDgv).BeginInit();
            SuspendLayout();
            // 
            // requestDgv
            // 
            requestDgv.AllowUserToAddRows = false;
            requestDgv.AllowUserToDeleteRows = false;
            requestDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            requestDgv.Location = new Point(12, 11);
            requestDgv.Margin = new Padding(3, 2, 3, 2);
            requestDgv.Name = "requestDgv";
            requestDgv.ReadOnly = true;
            requestDgv.RowHeadersWidth = 51;
            requestDgv.RowTemplate.Height = 29;
            requestDgv.Size = new Size(778, 141);
            requestDgv.TabIndex = 0;
            requestDgv.CellDoubleClick += requestDgv_CellDoubleClick;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(205, 174);
            name.Name = "name";
            name.Size = new Size(39, 15);
            name.TabIndex = 1;
            name.Text = "Name";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(205, 304);
            email.Name = "email";
            email.Size = new Size(36, 15);
            email.TabIndex = 2;
            email.Text = "Email";
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSize = true;
            phoneNumber.Location = new Point(205, 243);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(88, 15);
            phoneNumber.TabIndex = 3;
            phoneNumber.Text = "Phone Number";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(378, 204);
            description.Name = "description";
            description.Size = new Size(67, 15);
            description.TabIndex = 4;
            description.Text = "Description";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(205, 371);
            status.Name = "status";
            status.Size = new Size(39, 15);
            status.TabIndex = 5;
            status.Text = "Status";
            // 
            // submitDate
            // 
            submitDate.AutoSize = true;
            submitDate.Location = new Point(205, 438);
            submitDate.Name = "submitDate";
            submitDate.Size = new Size(72, 15);
            submitDate.TabIndex = 6;
            submitDate.Text = "Submit Date";
            // 
            // txtName
            // 
            txtName.Location = new Point(205, 198);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 23);
            txtName.TabIndex = 7;
            txtName.KeyPress += always_handled;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(205, 328);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 23);
            txtEmail.TabIndex = 8;
            txtEmail.KeyPress += event_handled;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(205, 268);
            txtPhone.Margin = new Padding(3, 2, 3, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(151, 23);
            txtPhone.TabIndex = 9;
            txtPhone.KeyPress += event_handled;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(378, 233);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(271, 255);
            txtDescription.TabIndex = 10;
            txtDescription.TextChanged += txtDescription_TextChanged;
            txtDescription.KeyPress += event_handled;
            // 
            // acceptBtn
            // 
            acceptBtn.AutoSize = true;
            acceptBtn.Enabled = false;
            acceptBtn.Location = new Point(676, 187);
            acceptBtn.Margin = new Padding(3, 2, 3, 2);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(114, 48);
            acceptBtn.TabIndex = 13;
            acceptBtn.Text = "Accept Request";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // denyBtn
            // 
            denyBtn.AutoSize = true;
            denyBtn.Enabled = false;
            denyBtn.Location = new Point(676, 249);
            denyBtn.Margin = new Padding(3, 2, 3, 2);
            denyBtn.Name = "denyBtn";
            denyBtn.Size = new Size(114, 48);
            denyBtn.TabIndex = 14;
            denyBtn.Text = "Deny Request";
            denyBtn.UseVisualStyleBackColor = true;
            denyBtn.Click += denyBtn_Click;
            // 
            // removeBtn
            // 
            removeBtn.AutoSize = true;
            removeBtn.Enabled = false;
            removeBtn.Location = new Point(676, 440);
            removeBtn.Margin = new Padding(3, 2, 3, 2);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(114, 48);
            removeBtn.TabIndex = 15;
            removeBtn.Text = "Remove Request";
            removeBtn.UseVisualStyleBackColor = true;
            removeBtn.Click += removeBtn_Click;
            // 
            // backBtn
            // 
            backBtn.AutoSize = true;
            backBtn.Location = new Point(12, 440);
            backBtn.Margin = new Padding(3, 2, 3, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(114, 48);
            backBtn.TabIndex = 16;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // addBtn
            // 
            addBtn.AutoSize = true;
            addBtn.Location = new Point(676, 373);
            addBtn.Margin = new Padding(3, 2, 3, 2);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(114, 48);
            addBtn.TabIndex = 17;
            addBtn.Text = "Add Request";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 255);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(120, 23);
            txtSearch.TabIndex = 20;
            txtSearch.TextChanged += searchText;
            // 
            // searchList
            // 
            searchList.AutoSize = true;
            searchList.Location = new Point(12, 163);
            searchList.Name = "searchList";
            searchList.Size = new Size(60, 15);
            searchList.TabIndex = 21;
            searchList.Text = "Search list";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(205, 465);
            txtDate.Margin = new Padding(3, 2, 3, 2);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(151, 23);
            txtDate.TabIndex = 12;
            txtDate.KeyPress += always_handled;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(205, 398);
            txtStatus.Margin = new Padding(3, 2, 3, 2);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(151, 23);
            txtStatus.TabIndex = 23;
            txtStatus.KeyPress += always_handled;
            // 
            // clearSearch
            // 
            clearSearch.AutoSize = true;
            clearSearch.Location = new Point(137, 255);
            clearSearch.Margin = new Padding(3, 2, 3, 2);
            clearSearch.Name = "clearSearch";
            clearSearch.Size = new Size(46, 25);
            clearSearch.TabIndex = 24;
            clearSearch.Text = "Clear";
            clearSearch.UseVisualStyleBackColor = true;
            clearSearch.Click += clearSearch_Click;
            // 
            // order
            // 
            order.Cursor = Cursors.Hand;
            order.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            order.Location = new Point(150, 186);
            order.Name = "order";
            order.Size = new Size(24, 21);
            order.TabIndex = 18;
            order.Text = "^";
            order.TextAlign = ContentAlignment.MiddleCenter;
            order.Click += order_Click;
            // 
            // searchBox
            // 
            searchBox.FormattingEnabled = true;
            searchBox.Location = new Point(12, 187);
            searchBox.Margin = new Padding(3, 2, 3, 2);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(120, 23);
            searchBox.TabIndex = 19;
            searchBox.SelectedIndexChanged += searchIndexChanged;
            // 
            // search
            // 
            search.AutoSize = true;
            search.Location = new Point(12, 217);
            search.Name = "search";
            search.Size = new Size(165, 30);
            search.TabIndex = 26;
            search.Text = "Search by customer name\r\n(Remember only accept telex)\r\n";
            // 
            // cancelBtn
            // 
            cancelBtn.AutoSize = true;
            cancelBtn.Location = new Point(676, 373);
            cancelBtn.Margin = new Padding(3, 2, 3, 2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(114, 48);
            cancelBtn.TabIndex = 27;
            cancelBtn.Text = "Cancel Request";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Visible = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // confirmBtn
            // 
            confirmBtn.AutoSize = true;
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(676, 308);
            confirmBtn.Margin = new Padding(3, 2, 3, 2);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(114, 48);
            confirmBtn.TabIndex = 28;
            confirmBtn.Text = "Confirm Request";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // checkBtn
            // 
            checkBtn.AutoSize = true;
            checkBtn.Location = new Point(451, 174);
            checkBtn.Margin = new Padding(3, 2, 3, 2);
            checkBtn.Name = "checkBtn";
            checkBtn.Size = new Size(95, 47);
            checkBtn.TabIndex = 30;
            checkBtn.Text = "Check Request";
            checkBtn.UseVisualStyleBackColor = true;
            checkBtn.Click += checkBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.AutoSize = true;
            clearBtn.Location = new Point(560, 174);
            clearBtn.Margin = new Padding(3, 2, 3, 2);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(89, 47);
            clearBtn.TabIndex = 31;
            clearBtn.Text = "Clear Request";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // textCount
            // 
            textCount.AutoSize = true;
            textCount.Location = new Point(549, 468);
            textCount.Name = "textCount";
            textCount.Size = new Size(52, 15);
            textCount.TabIndex = 32;
            textCount.Text = "Count: 0";
            // 
            // Request
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 502);
            Controls.Add(textCount);
            Controls.Add(clearBtn);
            Controls.Add(checkBtn);
            Controls.Add(confirmBtn);
            Controls.Add(cancelBtn);
            Controls.Add(search);
            Controls.Add(clearSearch);
            Controls.Add(txtStatus);
            Controls.Add(searchList);
            Controls.Add(txtSearch);
            Controls.Add(searchBox);
            Controls.Add(order);
            Controls.Add(addBtn);
            Controls.Add(backBtn);
            Controls.Add(removeBtn);
            Controls.Add(denyBtn);
            Controls.Add(acceptBtn);
            Controls.Add(txtDate);
            Controls.Add(txtDescription);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(submitDate);
            Controls.Add(status);
            Controls.Add(description);
            Controls.Add(phoneNumber);
            Controls.Add(email);
            Controls.Add(name);
            Controls.Add(requestDgv);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Request";
            Text = "Request";
            ((System.ComponentModel.ISupportInitialize)requestDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView requestDgv;
        private Label name;
        private Label email;
        private Label phoneNumber;
        private Label description;
        private Label status;
        private Label submitDate;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtDescription;
        private Button acceptBtn;
        private Button denyBtn;
        private Button removeBtn;
        private Button backBtn;
        private Button addBtn;
        private TextBox txtSearch;
        private Label searchList;
        private TextBox txtDate;
        private TextBox txtStatus;
        private Button clearSearch;
        private Label order;
        private ComboBox searchBox;
        private Label search;
        private Button cancelBtn;
        private Button confirmBtn;
        private Button checkBtn;
        private Button clearBtn;
        private Label textCount;
    }
}