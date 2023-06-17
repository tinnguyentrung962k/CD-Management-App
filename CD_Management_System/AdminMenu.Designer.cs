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
            SuspendLayout();
            // 
            // btnEmployeeManagement
            // 
            btnEmployeeManagement.Location = new Point(91, 80);
            btnEmployeeManagement.Name = "btnEmployeeManagement";
            btnEmployeeManagement.Size = new Size(179, 23);
            btnEmployeeManagement.TabIndex = 0;
            btnEmployeeManagement.Text = "Employee Management";
            btnEmployeeManagement.UseVisualStyleBackColor = true;
            btnEmployeeManagement.Click += btnEmployeeManagement_Click;
            // 
            // btnAlbumManagement
            // 
            btnAlbumManagement.Location = new Point(91, 146);
            btnAlbumManagement.Name = "btnAlbumManagement";
            btnAlbumManagement.Size = new Size(179, 23);
            btnAlbumManagement.TabIndex = 1;
            btnAlbumManagement.Text = "Album Management";
            btnAlbumManagement.UseVisualStyleBackColor = true;
            btnAlbumManagement.Click += btnAlbumManagement_Click;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 268);
            Controls.Add(btnAlbumManagement);
            Controls.Add(btnEmployeeManagement);
            Name = "AdminMenu";
            Text = "Admin Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEmployeeManagement;
        private Button btnAlbumManagement;
    }
}