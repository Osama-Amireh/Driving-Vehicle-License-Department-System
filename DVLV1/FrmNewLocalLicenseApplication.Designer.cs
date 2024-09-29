namespace DVLV1
{
    partial class FrmNewLocalLicenseApplication
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
            this.TcNewlicense = new System.Windows.Forms.TabControl();
            this.TpPersoanlInfo = new System.Windows.Forms.TabPage();
            this.TpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.personCardWithFilter1 = new DVLV1.PersonCardWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.CbClass = new System.Windows.Forms.ComboBox();
            this.lblFee = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.TcNewlicense.SuspendLayout();
            this.TpPersoanlInfo.SuspendLayout();
            this.TpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TcNewlicense
            // 
            this.TcNewlicense.Controls.Add(this.TpPersoanlInfo);
            this.TcNewlicense.Controls.Add(this.TpApplicationInfo);
            this.TcNewlicense.Location = new System.Drawing.Point(36, 62);
            this.TcNewlicense.Name = "TcNewlicense";
            this.TcNewlicense.SelectedIndex = 0;
            this.TcNewlicense.Size = new System.Drawing.Size(886, 546);
            this.TcNewlicense.TabIndex = 0;
            // 
            // TpPersoanlInfo
            // 
            this.TpPersoanlInfo.Controls.Add(this.personCardWithFilter1);
            this.TpPersoanlInfo.Controls.Add(this.btnNext);
            this.TpPersoanlInfo.Location = new System.Drawing.Point(4, 25);
            this.TpPersoanlInfo.Name = "TpPersoanlInfo";
            this.TpPersoanlInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TpPersoanlInfo.Size = new System.Drawing.Size(878, 517);
            this.TpPersoanlInfo.TabIndex = 0;
            this.TpPersoanlInfo.Text = "Personal Info";
            this.TpPersoanlInfo.UseVisualStyleBackColor = true;
            // 
            // TpApplicationInfo
            // 
            this.TpApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.TpApplicationInfo.Controls.Add(this.lblFee);
            this.TpApplicationInfo.Controls.Add(this.CbClass);
            this.TpApplicationInfo.Controls.Add(this.lblData);
            this.TpApplicationInfo.Controls.Add(this.label6);
            this.TpApplicationInfo.Controls.Add(this.pictureBox5);
            this.TpApplicationInfo.Controls.Add(this.pictureBox4);
            this.TpApplicationInfo.Controls.Add(this.pictureBox3);
            this.TpApplicationInfo.Controls.Add(this.pictureBox2);
            this.TpApplicationInfo.Controls.Add(this.pictureBox1);
            this.TpApplicationInfo.Controls.Add(this.label5);
            this.TpApplicationInfo.Controls.Add(this.label4);
            this.TpApplicationInfo.Controls.Add(this.label3);
            this.TpApplicationInfo.Controls.Add(this.label2);
            this.TpApplicationInfo.Controls.Add(this.label1);
            this.TpApplicationInfo.Location = new System.Drawing.Point(4, 25);
            this.TpApplicationInfo.Name = "TpApplicationInfo";
            this.TpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TpApplicationInfo.Size = new System.Drawing.Size(878, 517);
            this.TpApplicationInfo.TabIndex = 1;
            this.TpApplicationInfo.Text = "Application Info";
            this.TpApplicationInfo.UseVisualStyleBackColor = true;
            this.TpApplicationInfo.Click += new System.EventHandler(this.TpApplicationInfo_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(315, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(372, 26);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "New Local Driving license Application";
            // 
            // personCardWithFilter1
            // 
            this.personCardWithFilter1.Location = new System.Drawing.Point(49, 6);
            this.personCardWithFilter1.Name = "personCardWithFilter1";
            this.personCardWithFilter1.Size = new System.Drawing.Size(777, 447);
            this.personCardWithFilter1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "D.L Application ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "license Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fee:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Created By:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::DVLV1.Properties.Resources.close__2_;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(672, 614);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 48);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLV1.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(821, 614);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 48);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLV1.Properties.Resources.arrow_right;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(737, 473);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 38);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLV1.Properties.Resources.public_document;
            this.pictureBox5.Location = new System.Drawing.Point(227, 334);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLV1.Properties.Resources.salary;
            this.pictureBox4.Location = new System.Drawing.Point(227, 277);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLV1.Properties.Resources.id;
            this.pictureBox3.Location = new System.Drawing.Point(227, 210);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLV1.Properties.Resources.calendar_week;
            this.pictureBox2.Location = new System.Drawing.Point(227, 145);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV1.Properties.Resources.field_numeric;
            this.pictureBox1.Location = new System.Drawing.Point(227, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(301, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "[???]";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(301, 146);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(42, 20);
            this.lblData.TabIndex = 19;
            this.lblData.Text = "[???]";
            // 
            // CbClass
            // 
            this.CbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbClass.FormattingEnabled = true;
            this.CbClass.Location = new System.Drawing.Point(291, 213);
            this.CbClass.Name = "CbClass";
            this.CbClass.Size = new System.Drawing.Size(173, 24);
            this.CbClass.TabIndex = 20;
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFee.Location = new System.Drawing.Point(301, 267);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(42, 20);
            this.lblFee.TabIndex = 21;
            this.lblFee.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(301, 334);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(42, 20);
            this.lblCreatedBy.TabIndex = 22;
            this.lblCreatedBy.Text = "[???]";
            // 
            // FrmNewLocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 664);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.TcNewlicense);
            this.Name = "FrmNewLocalLicenseApplication";
            this.Text = "FrmNewLocalLicenseApplication";
            this.Load += new System.EventHandler(this.FrmNewLocalLicenseApplication_Load);
            this.TcNewlicense.ResumeLayout(false);
            this.TpPersoanlInfo.ResumeLayout(false);
            this.TpApplicationInfo.ResumeLayout(false);
            this.TpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcNewlicense;
        private System.Windows.Forms.TabPage TpPersoanlInfo;
        private System.Windows.Forms.TabPage TpApplicationInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private PersonCardWithFilter personCardWithFilter1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblFee;
    }
}