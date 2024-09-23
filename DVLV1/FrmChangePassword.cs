using DVLD_businessLayer;
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
    public partial class FrmChangePassword : Form
    {
        private clsUser _User;
        public FrmChangePassword()
        {
            InitializeComponent();
        }
        public FrmChangePassword(int ID)
        {
            InitializeComponent();
            ctrlUserDetails1.LoadInfo(ID);
            _User=clsUser.FindUserByID(ID);
        }

        private void ctrlUserDetails1_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
           


        }
        private bool _Validate()
        {
            bool _IsValidate = true;
            if (string.IsNullOrEmpty(txtBoxCurrentPassword.Text))
            {
                errorProvider1.SetError(txtBoxCurrentPassword, "Require");
                _IsValidate = false;

            }
            else if (_User.Password != txtBoxCurrentPassword.Text)
            {
                errorProvider1.SetError(txtBoxCurrentPassword, "Invalid Password");
                _IsValidate = false;
            }
            else 
            {
                errorProvider1.SetError(txtBoxCurrentPassword, "");
                _IsValidate = true;
            }
            if (string.IsNullOrEmpty(txtBoxNewPassword.Text))
            {
                errorProvider2.SetError(txtBoxNewPassword, "Require");
                _IsValidate = false;

            }
            else if (txtBoxNewPassword.Text == txtBoxCurrentPassword.Text)
            {
                errorProvider2.SetError(txtBoxNewPassword, "Must New Password different of Current Password");
                _IsValidate = false;


            }
            else
            {
                errorProvider2.SetError(txtBoxNewPassword, "");
                _IsValidate = true;

            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider3.SetError(txtConfirmPassword, "Require");
                _IsValidate = false;

            }
            else if (txtConfirmPassword.Text != txtBoxNewPassword.Text)
            {
                errorProvider3.SetError(txtConfirmPassword, "Invalid Password");
                _IsValidate = false;

            }
            else
            {

                errorProvider3.SetError(txtConfirmPassword, "");
                _IsValidate = true;
            }
        return _IsValidate;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Validate() == true)
            { 
                _User.Password = txtBoxNewPassword.Text;
            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Data dose not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
