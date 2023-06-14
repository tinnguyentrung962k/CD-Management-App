using System.Runtime.CompilerServices;

namespace CD_Management_System
{
    partial class SongManagement
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
            dgvSongList = new DataGridView();
            label5 = new Label();
            create = new Button();
            update = new Button();
            delete = new Button();
            cancel = new Button();
            label9 = new Label();
            txtSongName = new TextBox();
            label10 = new Label();
            txtDuration = new TextBox();
            label12 = new Label();
            intSongID = new TextBox();
            txtLog = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSongList).BeginInit();
            SuspendLayout();
            // 
            // dgvSongList
            // 
            dgvSongList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongList.Location = new Point(10, 11);
            dgvSongList.Margin = new Padding(3, 2, 3, 2);
            dgvSongList.Name = "dgvSongList";
            dgvSongList.RowHeadersWidth = 51;
            dgvSongList.RowTemplate.Height = 29;
            dgvSongList.Size = new Size(524, 341);
            dgvSongList.TabIndex = 1;
            dgvSongList.CellClick += chooseSong;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(540, 128);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 12;
            // 
            // create
            // 
            create.Location = new Point(539, 114);
            create.Name = "create";
            create.Size = new Size(75, 23);
            create.TabIndex = 17;
            create.Text = "Create";
            create.UseVisualStyleBackColor = true;
            create.Click += operation;
            // 
            // update
            // 
            update.Location = new Point(539, 143);
            update.Name = "update";
            update.Size = new Size(75, 23);
            update.TabIndex = 18;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            update.Click += operation;
            // 
            // delete
            // 
            delete.Location = new Point(540, 172);
            delete.Name = "delete";
            delete.Size = new Size(75, 23);
            delete.TabIndex = 19;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += operation;
            // 
            // cancel
            // 
            cancel.Location = new Point(540, 201);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 20;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += operation;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(540, 43);
            label9.Name = "label9";
            label9.Size = new Size(69, 15);
            label9.TabIndex = 21;
            label9.Text = "Song Name";
            // 
            // txtSongName
            // 
            txtSongName.Location = new Point(621, 40);
            txtSongName.Name = "txtSongName";
            txtSongName.Size = new Size(280, 23);
            txtSongName.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(540, 72);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 23;
            label10.Text = "Duration";
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(621, 69);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(280, 23);
            txtDuration.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(540, 15);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 27;
            label12.Text = "Song ID";
            // 
            // intSongID
            // 
            intSongID.Location = new Point(621, 12);
            intSongID.Name = "intSongID";
            intSongID.Size = new Size(280, 23);
            intSongID.TabIndex = 28;
            // 
            // txtLog
            // 
            txtLog.AutoSize = true;
            txtLog.Location = new Point(631, 114);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(69, 15);
            txtLog.TabIndex = 29;
            txtLog.Text = "Adu ghi log";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(820, 326);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 30;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += closeForm;
            // 
            // SongManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 361);
            Controls.Add(btnClose);
            Controls.Add(txtLog);
            Controls.Add(intSongID);
            Controls.Add(label12);
            Controls.Add(txtDuration);
            Controls.Add(label10);
            Controls.Add(txtSongName);
            Controls.Add(label9);
            Controls.Add(cancel);
            Controls.Add(delete);
            Controls.Add(update);
            Controls.Add(create);
            Controls.Add(label5);
            Controls.Add(dgvSongList);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SongManagement";
            Text = "Song In Album";
            ((System.ComponentModel.ISupportInitialize)dgvSongList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvSongList;
        private Label label5;
        private Button create;
        private Button update;
        private Button delete;
        private Button cancel;
        private Label label9;
        private TextBox txtSongName;
        private Label label10;
        private TextBox txtDuration;
        private Label label12;
        private TextBox intSongID;
        private Label txtLog;
        private Button btnClose;
    }
}