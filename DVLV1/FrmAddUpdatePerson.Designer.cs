namespace DVLV1
{
    partial class FrmAddUpdatePerson
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
            this.uctrlAddUpdatePerson1 = new DVLV1.UctrlAddUpdatePerson();
            this.SuspendLayout();
            // 
            // uctrlAddUpdatePerson1
            // 
            this.uctrlAddUpdatePerson1.Location = new System.Drawing.Point(22, 21);
            this.uctrlAddUpdatePerson1.Name = "uctrlAddUpdatePerson1";
            this.uctrlAddUpdatePerson1.Size = new System.Drawing.Size(855, 495);
            this.uctrlAddUpdatePerson1.TabIndex = 0;
            this.uctrlAddUpdatePerson1.OnPersonDataChanged += new System.Action<DVLD_businessLayer.clsPerson>(this.uctrlAddUpdatePerson1_OnPersonDataChanged);
            this.uctrlAddUpdatePerson1.Load += new System.EventHandler(this.uctrlAddUpdatePerson1_Load);
            // 
            // FrmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 540);
            this.Controls.Add(this.uctrlAddUpdatePerson1);
            this.Name = "FrmAddUpdatePerson";
            this.Text = "FrmAddUpdatePerson";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddUpdatePerson_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddUpdatePerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UctrlAddUpdatePerson uctrlAddUpdatePerson1;
    }
}