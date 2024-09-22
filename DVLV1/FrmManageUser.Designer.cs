namespace DVLV1
{
    partial class FrmManageUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterUser = new System.Windows.Forms.ComboBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumRecords = new System.Windows.Forms.Label();
            this.btcClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(376, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterUser
            // 
            this.cbFilterUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterUser.FormattingEnabled = true;
            this.cbFilterUser.Items.AddRange(new object[] {
            "None",
            "User ID",
            "User name",
            "Person ID",
            "Full Name",
            "Is Active"});
            this.cbFilterUser.Location = new System.Drawing.Point(93, 185);
            this.cbFilterUser.Name = "cbFilterUser";
            this.cbFilterUser.Size = new System.Drawing.Size(141, 24);
            this.cbFilterUser.TabIndex = 3;
            this.cbFilterUser.SelectedIndexChanged += new System.EventHandler(this.cbFilterUser_SelectedIndexChanged);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(-7, 234);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(909, 295);
            this.dgvUsers.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Records:";
            // 
            // lblNumRecords
            // 
            this.lblNumRecords.AutoSize = true;
            this.lblNumRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecords.Location = new System.Drawing.Point(118, 542);
            this.lblNumRecords.Name = "lblNumRecords";
            this.lblNumRecords.Size = new System.Drawing.Size(26, 18);
            this.lblNumRecords.TabIndex = 7;
            this.lblNumRecords.Text = "??";
            // 
            // btcClose
            // 
            this.btcClose.Image = global::DVLV1.Properties.Resources.close__2_;
            this.btcClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btcClose.Location = new System.Drawing.Point(777, 533);
            this.btcClose.Name = "btcClose";
            this.btcClose.Size = new System.Drawing.Size(119, 39);
            this.btcClose.TabIndex = 8;
            this.btcClose.Text = "Close";
            this.btcClose.UseVisualStyleBackColor = true;
            this.btcClose.Click += new System.EventHandler(this.btcClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV1.Properties.Resources.user__3_;
            this.pictureBox1.Location = new System.Drawing.Point(416, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = global::DVLV1.Properties.Resources.user_add;
            this.btnAddUser.Location = new System.Drawing.Point(800, 135);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(96, 90);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Location = new System.Drawing.Point(252, 185);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(145, 22);
            this.txtBoxFilter.TabIndex = 10;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.txtBoxFilter_TextChanged);
            // 
            // CbIsActive
            // 
            this.CbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbIsActive.FormattingEnabled = true;
            this.CbIsActive.Items.AddRange(new object[] {
            "All ",
            "Yes",
            "No"});
            this.CbIsActive.Location = new System.Drawing.Point(252, 185);
            this.CbIsActive.Name = "CbIsActive";
            this.CbIsActive.Size = new System.Drawing.Size(145, 24);
            this.CbIsActive.TabIndex = 11;
            this.CbIsActive.SelectedIndexChanged += new System.EventHandler(this.CbIsActive_SelectedIndexChanged);
            // 
            // FrmManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 579);
            this.Controls.Add(this.CbIsActive);
            this.Controls.Add(this.txtBoxFilter);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btcClose);
            this.Controls.Add(this.lblNumRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.cbFilterUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmManageUser";
            this.Text = "FrmManageUser";
            this.Load += new System.EventHandler(this.FrmManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumRecords;
        private System.Windows.Forms.Button btcClose;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CbIsActive;
    }
}