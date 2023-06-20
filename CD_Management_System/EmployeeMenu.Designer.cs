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
            btnLogout = new Button();
            totalAlbum = new Label();
            totalSong = new Label();
            totalRequest = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnAlbumManagement
            // 
            btnAlbumManagement.Location = new Point(451, 103);
            btnAlbumManagement.Name = "btnAlbumManagement";
            btnAlbumManagement.Size = new Size(245, 50);
            btnAlbumManagement.TabIndex = 0;
            btnAlbumManagement.Text = "Album Management";
            btnAlbumManagement.UseVisualStyleBackColor = true;
            btnAlbumManagement.Click += btnAlbumManagement_Click;
            // 
            // btnRequestManagement
            // 
            btnRequestManagement.Location = new Point(451, 220);
            btnRequestManagement.Name = "btnRequestManagement";
            btnRequestManagement.Size = new Size(245, 50);
            btnRequestManagement.TabIndex = 1;
            btnRequestManagement.Text = "Request Management";
            btnRequestManagement.UseVisualStyleBackColor = true;
            btnRequestManagement.Click += btnRequestManagement_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(689, 13);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(111, 35);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // totalAlbum
            // 
            totalAlbum.AutoSize = true;
            totalAlbum.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalAlbum.ForeColor = Color.White;
            totalAlbum.Location = new Point(0, 23);
            totalAlbum.Name = "totalAlbum";
            totalAlbum.Size = new Size(81, 35);
            totalAlbum.TabIndex = 3;
            totalAlbum.Text = "label1";
            // 
            // totalSong
            // 
            totalSong.AutoSize = true;
            totalSong.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalSong.ForeColor = Color.White;
            totalSong.Location = new Point(0, 23);
            totalSong.Name = "totalSong";
            totalSong.Size = new Size(81, 35);
            totalSong.TabIndex = 4;
            totalSong.Text = "label1";
            // 
            // totalRequest
            // 
            totalRequest.AutoSize = true;
            totalRequest.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            totalRequest.ForeColor = Color.White;
            totalRequest.Location = new Point(0, 23);
            totalRequest.Name = "totalRequest";
            totalRequest.Size = new Size(81, 35);
            totalRequest.TabIndex = 5;
            totalRequest.Text = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(288, 41);
            label1.TabIndex = 7;
            label1.Text = "Welcome, Employee";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Blue;
            panel2.Controls.Add(totalAlbum);
            panel2.Location = new Point(52, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 58);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Orange;
            panel3.Controls.Add(totalSong);
            panel3.Location = new Point(52, 200);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 58);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Green;
            panel4.Controls.Add(totalRequest);
            panel4.Location = new Point(52, 299);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 58);
            panel4.TabIndex = 8;
            // 
            // EmployeeMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnRequestManagement);
            Controls.Add(btnAlbumManagement);
            Name = "EmployeeMenu";
            Text = "EmployeeMenu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAlbumManagement;
        private Button btnRequestManagement;
        private Button btnLogout;
        private Label totalAlbum;
        private Label totalSong;
        private Label totalRequest;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}