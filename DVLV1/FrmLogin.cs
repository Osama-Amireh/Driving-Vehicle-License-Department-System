using DVLD_businessLayer;
using DVLDClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV1
{
    public partial class FrmLogin : Form
    {
        public clsUser User;
        public FrmLogin()
        {
            InitializeComponent();
        }
        private bool Validate()
        {
            bool IsValid=true;
            if(string.IsNullOrEmpty(txtBoxUserName.Text))
                {
                IsValid = false;

                errorProvider1.SetError(txtBoxUserName, "Reqiure");
                  }
            if (string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                IsValid = false;

                errorProvider2.SetError(txtBoxPassword, "Reqiure");
            }
            return IsValid;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Validate())
            {
                User = clsUser.LoginByUsernameAndPassword(txtBoxUserName.Text.Trim(), txtBoxPassword.Text.Trim());
                if (User != null)
                {
                    if (User.IsActive == true)
                    {
                        if(ckRemember.Checked==true)
                        {
                            clsGlobal.RememberUsernameAndPassword(txtBoxUserName.Text, txtBoxPassword.Text);
                        }
                        else
                        {
                            clsGlobal.RememberUsernameAndPassword("","");

                        }

                    }
                    else
                    {
                        txtBoxUserName.Focus();
                        MessageBox.Show("This User deactivate please admin review ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    clsGlobal.CurrentUser = User;
                    this.Hide();
                    FrmMain frmMain = new FrmMain(this);
                    frmMain.ShowDialog();

                }
                else
                {
                    txtBoxUserName.Focus();
                    MessageBox.Show("Invalid Username/Password ", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobal.GetStoredUsernameAndPassword(ref Username, ref Password))
            {
                txtBoxUserName.Text = Username;
                txtBoxPassword.Text = Password;
                ckRemember.Checked = true;
            }
            else
            {
                ckRemember.Checked = false;

            }
        }
    }
}
