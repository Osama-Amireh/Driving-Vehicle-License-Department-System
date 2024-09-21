namespace DVLV1
{
    partial class FrmPersonDetails
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
            this.uCtrlPersonDetailes1 = new DVLV1.UCtrlPersonDetailes();
            this.SuspendLayout();
            // 
            // uCtrlPersonDetailes1
            // 
            this.uCtrlPersonDetailes1.Location = new System.Drawing.Point(12, 7);
            this.uCtrlPersonDetailes1.Name = "uCtrlPersonDetailes1";
            this.uCtrlPersonDetailes1.Size = new System.Drawing.Size(766, 471);
            this.uCtrlPersonDetailes1.TabIndex = 0;
            // 
            // FrmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 490);
            this.Controls.Add(this.uCtrlPersonDetailes1);
            this.Name = "FrmPersonDetails";
            this.Text = "FrmPersonDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private UCtrlPersonDetailes uCtrlPersonDetailes1;
    }
}