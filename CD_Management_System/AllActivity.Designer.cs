namespace CD_Management_System
{
    partial class AllActivity
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
            dgvActivityList = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvActivityList).BeginInit();
            SuspendLayout();
            // 
            // dgvActivityList
            // 
            dgvActivityList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActivityList.Location = new Point(12, 12);
            dgvActivityList.Name = "dgvActivityList";
            dgvActivityList.RowHeadersWidth = 51;
            dgvActivityList.RowTemplate.Height = 29;
            dgvActivityList.Size = new Size(910, 482);
            dgvActivityList.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(928, 426);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 68);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // AllActivity
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 506);
            Controls.Add(btnBack);
            Controls.Add(dgvActivityList);
            Name = "AllActivity";
            Text = "AllActivity";
            ((System.ComponentModel.ISupportInitialize)dgvActivityList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvActivityList;
        private Button btnBack;
    }
}