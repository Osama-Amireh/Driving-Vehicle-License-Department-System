namespace DVLV1
{
    partial class FrmApplicationsTypes
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvApplicaionsTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplictionTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicaionsTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV1.Properties.Resources.tasks_report;
            this.pictureBox1.Location = new System.Drawing.Point(311, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(245, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Applications Types";
            // 
            // dgvApplicaionsTypes
            // 
            this.dgvApplicaionsTypes.AllowUserToAddRows = false;
            this.dgvApplicaionsTypes.AllowUserToDeleteRows = false;
            this.dgvApplicaionsTypes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplicaionsTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicaionsTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplicaionsTypes.Location = new System.Drawing.Point(16, 234);
            this.dgvApplicaionsTypes.Name = "dgvApplicaionsTypes";
            this.dgvApplicaionsTypes.ReadOnly = true;
            this.dgvApplicaionsTypes.RowHeadersWidth = 51;
            this.dgvApplicaionsTypes.RowTemplate.Height = 24;
            this.dgvApplicaionsTypes.Size = new System.Drawing.Size(797, 423);
            this.dgvApplicaionsTypes.TabIndex = 2;
            this.dgvApplicaionsTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplicaionsTypes_CellClick);
            this.dgvApplicaionsTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplicaionsTypes_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplictionTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 30);
            // 
            // editApplictionTypeToolStripMenuItem
            // 
            this.editApplictionTypeToolStripMenuItem.Image = global::DVLV1.Properties.Resources.edit;
            this.editApplictionTypeToolStripMenuItem.Name = "editApplictionTypeToolStripMenuItem";
            this.editApplictionTypeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.editApplictionTypeToolStripMenuItem.Text = "Edit Appliction Type";
            this.editApplictionTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplictionTypeToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLV1.Properties.Resources.close__2_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(681, 663);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 44);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 672);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(106, 672);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(24, 22);
            this.lblRecords.TabIndex = 5;
            this.lblRecords.Text = "??";
            // 
            // FrmApplicationsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 709);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvApplicaionsTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmApplicationsTypes";
            this.Text = "Manage Applications Types";
            this.Load += new System.EventHandler(this.FrmApplicationsTypes_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmApplicationsTypes_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicaionsTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvApplicaionsTypes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplictionTypeToolStripMenuItem;
    }
}