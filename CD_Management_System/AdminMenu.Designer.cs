namespace CD_Management_System
{
    partial class AdminMenu
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
            btnEmployeeManagement = new Button();
            btnAlbumManagement = new Button();
            btnRequestManagement = new Button();
            btnLogout = new Button();
            totalAlbum = new Label();
            totalSong = new Label();
            totalRequest = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnActivityLog = new Button();
            txtTitleMng = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnEmployeeManagement
            // 
            btnEmployeeManagement.Location = new Point(364, 143);
            btnEmployeeManagement.Name = "btnEmployeeManagement";
            btnEmployeeManagement.Size = new Size(205, 40);
            btnEmployeeManagement.TabIndex = 0;
            btnEmployeeManagement.Text = "Employee Management";
            btnEmployeeManagement.UseVisualStyleBackColor = true;
            btnEmployeeManagement.Click += btnEmployeeManagement_Click;
            // 
            // btnAlbumManagement
            // 
            btnAlbumManagement.Location = new Point(364, 67);
            btnAlbumManagement.Name = "btnAlbumManagement";
            btnAlbumManagement.Size = new Size(205, 40);
            btnAlbumManagement.TabIndex = 1;
            btnAlbumManagement.Text = "Album Management";
            btnAlbumManagement.UseVisualStyleBackColor = true;
            btnAlbumManagement.Click += btnAlbumManagement_Click;
            // 
            // btnRequestManagement
            // 
            btnRequestManagement.Location = new Point(364, 220);
            btnRequestManagement.Name = "btnRequestManagement";
            btnRequestManagement.Size = new Size(205, 38);
            btnRequestManagement.TabIndex = 2;
            btnRequestManagement.Text = "Request Management";
            btnRequestManagement.UseVisualStyleBackColor = true;
            btnRequestManagement.Click += btnRequestManagement_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(542, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // totalAlbum
            // 
            totalAlbum.AutoSize = true;
            totalAlbum.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalAlbum.ForeColor = Color.White;
            totalAlbum.Location = new Point(0, 17);
            totalAlbum.Name = "totalAlbum";
            totalAlbum.Size = new Size(65, 28);
            totalAlbum.TabIndex = 4;
            totalAlbum.Text = "label1";
            // 
            // totalSong
            // 
            totalSong.AutoSize = true;
            totalSong.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalSong.ForeColor = Color.White;
            totalSong.Location = new Point(0, 17);
            totalSong.Name = "totalSong";
            totalSong.Size = new Size(65, 28);
            totalSong.TabIndex = 5;
            totalSong.Text = "label1";
            // 
            // totalRequest
            // 
            totalRequest.AutoSize = true;
            totalRequest.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalRequest.ForeColor = Color.White;
            totalRequest.Location = new Point(0, 17);
            totalRequest.Name = "totalRequest";
            totalRequest.Size = new Size(65, 28);
            totalRequest.TabIndex = 6;
            totalRequest.Text = "label1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Blue;
            panel2.Controls.Add(totalAlbum);
            panel2.Location = new Point(40, 62);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(192, 54);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Orange;
            panel3.Controls.Add(totalSong);
            panel3.Location = new Point(40, 138);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(192, 52);
            panel3.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Green;
            panel4.Controls.Add(totalRequest);
            panel4.Location = new Point(40, 220);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(192, 48);
            panel4.TabIndex = 10;
            // 
            // btnActivityLog
            // 
            btnActivityLog.Location = new Point(364, 298);
            btnActivityLog.Name = "btnActivityLog";
            btnActivityLog.Size = new Size(205, 38);
            btnActivityLog.TabIndex = 11;
            btnActivityLog.Text = "Activity Log";
            btnActivityLog.UseVisualStyleBackColor = true;
            btnActivityLog.Click += btnActivityLog_Click;
            // 
            // txtTitleMng
            // 
            txtTitleMng.AutoSize = true;
            txtTitleMng.BackColor = SystemColors.Control;
            txtTitleMng.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitleMng.ForeColor = SystemColors.ActiveCaptionText;
            txtTitleMng.Location = new Point(40, 9);
            txtTitleMng.Name = "txtTitleMng";
            txtTitleMng.Size = new Size(111, 32);
            txtTitleMng.TabIndex = 7;
            txtTitleMng.Text = "labelTitle";
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 387);
            Controls.Add(btnLogout);
            Controls.Add(txtTitleMng);
            Controls.Add(btnActivityLog);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnRequestManagement);
            Controls.Add(btnAlbumManagement);
            Controls.Add(btnEmployeeManagement);
            Name = "AdminMenu";
            Text = "Admin Menu";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmployeeManagement;
        private Button btnAlbumManagement;
        private Button btnRequestManagement;
        private Button btnLogout;
        private Label totalAlbum;
        private Label totalSong;
        private Label totalRequest;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnActivityLog;
        private Label txtTitleMng;
    }
}