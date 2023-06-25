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
            dgvActivityList.Location = new Point(10, 9);
            dgvActivityList.Margin = new Padding(3, 2, 3, 2);
            dgvActivityList.Name = "dgvActivityList";
            dgvActivityList.RowHeadersWidth = 51;
            dgvActivityList.RowTemplate.Height = 29;
            dgvActivityList.Size = new Size(1243, 362);
            dgvActivityList.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(1270, 320);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(175, 51);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // AllActivity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1457, 380);
            Controls.Add(btnBack);
            Controls.Add(dgvActivityList);
            Margin = new Padding(3, 2, 3, 2);
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