namespace CD_Management_System
{
    partial class EmployeeMenu
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
            btnAlbumManagement = new Button();
            btnRequestManagement = new Button();
            totalAlbum = new Label();
            totalSong = new Label();
            totalRequest = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnLogout = new Button();
            txtTitleEmp = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnAlbumManagement
            // 
            btnAlbumManagement.Location = new Point(418, 77);
            btnAlbumManagement.Margin = new Padding(3, 2, 3, 2);
            btnAlbumManagement.Name = "btnAlbumManagement";
            btnAlbumManagement.Size = new Size(149, 68);
            btnAlbumManagement.TabIndex = 0;
            btnAlbumManagement.Text = "Album Management";
            btnAlbumManagement.UseVisualStyleBackColor = true;
            btnAlbumManagement.Click += btnAlbumManagement_Click;
            // 
            // btnRequestManagement
            // 
            btnRequestManagement.Location = new Point(418, 176);
            btnRequestManagement.Margin = new Padding(3, 2, 3, 2);
            btnRequestManagement.Name = "btnRequestManagement";
            btnRequestManagement.Size = new Size(149, 67);
            btnRequestManagement.TabIndex = 1;
            btnRequestManagement.Text = "Request Management";
            btnRequestManagement.UseVisualStyleBackColor = true;
            btnRequestManagement.Click += btnRequestManagement_Click;
            // 
            // totalAlbum
            // 
            totalAlbum.AutoSize = true;
            totalAlbum.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalAlbum.ForeColor = Color.White;
            totalAlbum.Location = new Point(0, 17);
            totalAlbum.Name = "totalAlbum";
            totalAlbum.Size = new Size(65, 28);
            totalAlbum.TabIndex = 3;
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
            totalSong.TabIndex = 4;
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
            totalRequest.TabIndex = 5;
            totalRequest.Text = "label1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Blue;
            panel2.Controls.Add(totalAlbum);
            panel2.Location = new Point(46, 77);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(192, 53);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Orange;
            panel3.Controls.Add(totalSong);
            panel3.Location = new Point(46, 150);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(192, 52);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Green;
            panel4.Controls.Add(totalRequest);
            panel4.Location = new Point(46, 224);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(192, 51);
            panel4.TabIndex = 8;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(591, 11);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(97, 26);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtTitleEmp
            // 
            txtTitleEmp.AutoSize = true;
            txtTitleEmp.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitleEmp.Location = new Point(46, 9);
            txtTitleEmp.Name = "txtTitleEmp";
            txtTitleEmp.Size = new Size(111, 32);
            txtTitleEmp.TabIndex = 7;
            txtTitleEmp.Text = "labelTitle";
            // 
            // EmployeeMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(txtTitleEmp);
            Controls.Add(panel4);
            Controls.Add(btnLogout);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnRequestManagement);
            Controls.Add(btnAlbumManagement);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeeMenu";
            Text = "EmployeeMenu";
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

        private Button btnAlbumManagement;
        private Button btnRequestManagement;
        private Label totalAlbum;
        private Label totalSong;
        private Label totalRequest;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnLogout;
        private Label txtTitleEmp;
    }
}