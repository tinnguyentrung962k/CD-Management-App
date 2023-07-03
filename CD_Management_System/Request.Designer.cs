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
            confirmBtn = new Button();
            updateBtn = new Button();
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
            requestDgv.Location = new Point(14, 15);
            requestDgv.Name = "requestDgv";
            requestDgv.ReadOnly = true;
            requestDgv.RowHeadersWidth = 51;
            requestDgv.RowTemplate.Height = 29;
            requestDgv.Size = new Size(889, 188);
            requestDgv.TabIndex = 0;
            requestDgv.CellDoubleClick += requestDgv_CellDoubleClick;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(234, 232);
            name.Name = "name";
            name.Size = new Size(49, 20);
            name.TabIndex = 1;
            name.Text = "Name";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(234, 405);
            email.Name = "email";
            email.Size = new Size(46, 20);
            email.TabIndex = 2;
            email.Text = "Email";
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSize = true;
            phoneNumber.Location = new Point(234, 324);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(108, 20);
            phoneNumber.TabIndex = 3;
            phoneNumber.Text = "Phone Number";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(432, 272);
            description.Name = "description";
            description.Size = new Size(85, 20);
            description.TabIndex = 4;
            description.Text = "Description";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(234, 495);
            status.Name = "status";
            status.Size = new Size(49, 20);
            status.TabIndex = 5;
            status.Text = "Status";
            // 
            // submitDate
            // 
            submitDate.AutoSize = true;
            submitDate.Location = new Point(234, 584);
            submitDate.Name = "submitDate";
            submitDate.Size = new Size(92, 20);
            submitDate.TabIndex = 6;
            submitDate.Text = "Submit Date";
            // 
            // txtName
            // 
            txtName.Location = new Point(234, 264);
            txtName.Name = "txtName";
            txtName.Size = new Size(172, 27);
            txtName.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(234, 437);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(172, 27);
            txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(234, 357);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(172, 27);
            txtPhone.TabIndex = 9;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(432, 311);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(309, 339);
            txtDescription.TabIndex = 10;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // acceptBtn
            // 
            acceptBtn.AutoSize = true;
            acceptBtn.Enabled = false;
            acceptBtn.Location = new Point(773, 236);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(130, 64);
            acceptBtn.TabIndex = 13;
            acceptBtn.Text = "Accept Request";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // denyBtn
            // 
            denyBtn.AutoSize = true;
            denyBtn.Enabled = false;
            denyBtn.Location = new Point(773, 332);
            denyBtn.Name = "denyBtn";
            denyBtn.Size = new Size(130, 64);
            denyBtn.TabIndex = 14;
            denyBtn.Text = "Deny Request";
            denyBtn.UseVisualStyleBackColor = true;
            denyBtn.Click += denyBtn_Click;
            // 
            // removeBtn
            // 
            removeBtn.AutoSize = true;
            removeBtn.Enabled = false;
            removeBtn.Location = new Point(773, 587);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new Size(130, 64);
            removeBtn.TabIndex = 15;
            removeBtn.Text = "Remove Request";
            removeBtn.UseVisualStyleBackColor = true;
            removeBtn.Click += removeBtn_Click;
            // 
            // backBtn
            // 
            backBtn.AutoSize = true;
            backBtn.Location = new Point(14, 587);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(130, 64);
            backBtn.TabIndex = 16;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // addBtn
            // 
            addBtn.AutoSize = true;
            addBtn.Location = new Point(773, 497);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(130, 64);
            addBtn.TabIndex = 17;
            addBtn.Text = "Add Request";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 394);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(137, 27);
            txtSearch.TabIndex = 20;
            txtSearch.TextChanged += searchText;
            // 
            // searchList
            // 
            searchList.AutoSize = true;
            searchList.Location = new Point(14, 217);
            searchList.Name = "searchList";
            searchList.Size = new Size(142, 20);
            searchList.TabIndex = 21;
            searchList.Text = "Order by (Asc/Desc)";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(234, 620);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(172, 27);
            txtDate.TabIndex = 12;
            txtDate.KeyPress += always_handled;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(234, 531);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(172, 27);
            txtStatus.TabIndex = 23;
            txtStatus.KeyPress += always_handled;
            // 
            // clearSearch
            // 
            clearSearch.AutoSize = true;
            clearSearch.Location = new Point(14, 427);
            clearSearch.Name = "clearSearch";
            clearSearch.Size = new Size(53, 33);
            clearSearch.TabIndex = 24;
            clearSearch.Text = "Clear";
            clearSearch.UseVisualStyleBackColor = true;
            clearSearch.Click += clearSearch_Click;
            // 
            // order
            // 
            order.Cursor = Cursors.Hand;
            order.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            order.Location = new Point(171, 248);
            order.Name = "order";
            order.Size = new Size(27, 28);
            order.TabIndex = 18;
            order.Text = "^";
            order.TextAlign = ContentAlignment.MiddleCenter;
            order.Click += order_Click;
            // 
            // searchBox
            // 
            searchBox.FormattingEnabled = true;
            searchBox.Location = new Point(14, 249);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(137, 28);
            searchBox.TabIndex = 19;
            searchBox.SelectedIndexChanged += searchIndexChanged;
            // 
            // search
            // 
            search.AutoSize = true;
            search.Location = new Point(14, 299);
            search.Name = "search";
            search.Size = new Size(179, 100);
            search.TabIndex = 26;
            search.Text = "Search by customer name\r\n- put in full letter for \r\nvietnamese word\r\nEx: ê, ô, â,...\r\n\r\n";
            // 
            // confirmBtn
            // 
            confirmBtn.AutoSize = true;
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(773, 411);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(130, 64);
            confirmBtn.TabIndex = 28;
            confirmBtn.Text = "Confirm Request";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.AutoSize = true;
            updateBtn.Location = new Point(523, 236);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(130, 63);
            updateBtn.TabIndex = 30;
            updateBtn.Text = "Update Request";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.AutoSize = true;
            clearBtn.Location = new Point(659, 236);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(110, 63);
            clearBtn.TabIndex = 31;
            clearBtn.Text = "Clear Request";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // textCount
            // 
            textCount.AutoSize = true;
            textCount.Location = new Point(627, 624);
            textCount.Name = "textCount";
            textCount.Size = new Size(63, 20);
            textCount.TabIndex = 32;
            textCount.Text = "Count: 0";
            // 
            // Request
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 669);
            Controls.Add(textCount);
            Controls.Add(clearBtn);
            Controls.Add(updateBtn);
            Controls.Add(confirmBtn);
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
        private Button confirmBtn;
        private Button updateBtn;
        private Button clearBtn;
        private Label textCount;
    }
}