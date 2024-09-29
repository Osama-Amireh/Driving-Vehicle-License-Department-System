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
    public partial class FrmAddUpdateUser : Form
    {
        private clsUser _User;
        private int _UserID;
        public delegate void DataBackEventHandler(object seder, clsUser User);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;
        public FrmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public FrmAddUpdateUser(int ID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = ID;
        }
        private void personCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void _LoadData()
        {
            _User=clsUser.FindUserByID(this._UserID);
            personCardWithFilter1.groupBox1.Enabled =false;
            if (_User == null)
            {
                MessageBox.Show("No user with ID=" + _UserID, "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
                
            }
            lblUserID.Text=_User.UserID.ToString();
            txtBoxUsername.Text = _User.UserName.ToString();   
            txtBoxPasswoed.Text= _User.Password.ToString();
            txtBoxConfirmPasswoed.Text=_User.Password .ToString();
            ckbIsActive.Checked = _User.IsActive;
            personCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
    
        private void _ResetDefualtValue()
        {
            if(_Mode==enMode.Update)
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                tpLoginInfo.Enabled=true;
                btnSave.Enabled=true;
            }
            else
            {
                lblTitle.Text = "Add New User";
                this.Text = "New User";
                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;
                _User = new clsUser();
                personCardWithFilter1.FilterFocus();
            }
            txtBoxUsername.Text = "";
            txtBoxPasswoed.Text = "";
            txtBoxConfirmPasswoed.Text = "";
            ckbIsActive.Checked = true;
            
        }
        private void FrmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValue();
            if(enMode.Update==_Mode)
            {
                _LoadData();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (enMode.Update == _Mode)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled=true;
                TcUserInfo.SelectedTab =TcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            if(personCardWithFilter1.PersonID!=-1)
            {
                if(clsUser.IsUserExsistForPersonID(personCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has user ,choose another one", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    TcUserInfo.SelectedTab = TcUserInfo.TabPages["tpLoginInfo"];
                }

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personCardWithFilter1.FilterFocus();

            }
        }
        private bool _ValidateUserInfo()
        {
            bool IsValide = true;
            if(string.IsNullOrEmpty(txtBoxUsername.Text))
            {
                errorProvider1.SetError(txtBoxUsername, "Required");
                IsValide=false;
            }
            else if(clsUser.IsUserExsistByUserName(txtBoxUsername.Text)&&_Mode==enMode.AddNew)
            {
                errorProvider1.SetError(txtBoxUsername, "This Username already Exsist");
                IsValide = false;

            }
            else if(_User.UserName!=txtBoxUsername.Text&& clsUser.IsUserExsistByUserName(txtBoxUsername.Text))
            {
                errorProvider1.SetError(txtBoxUsername, "This Username already Exsist");

            }
            if (string.IsNullOrEmpty(txtBoxPasswoed.Text))
            {
                errorProvider2.SetError(txtBoxPasswoed, "Required");
                IsValide = false;
            }
            if (string.IsNullOrEmpty(txtBoxConfirmPasswoed.Text))
            {
                errorProvider3.SetError(txtBoxConfirmPasswoed, "Required");
                IsValide = false;

            }
            else if(txtBoxConfirmPasswoed.Text!=txtBoxPasswoed.Text)
            {
                errorProvider3.SetError(txtBoxConfirmPasswoed, "Incorrect");
                IsValide = false;

            }
            return IsValide;
        }
        private void _RemoveSetError()
        {
            errorProvider1.SetError(txtBoxUsername, "");
            errorProvider2.SetError(txtBoxPasswoed, "");
            errorProvider3.SetError(txtBoxConfirmPasswoed, "");

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_ValidateUserInfo())
            {
                MessageBox.Show("Some Fileds are not valide","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _User.PersonID = personCardWithFilter1.PersonID;
            _User.UserName = txtBoxUsername.Text.Trim();
            _User.Password = txtBoxPasswoed.Text.Trim();
            _User.IsActive = ckbIsActive.Checked;
            if(_User.Save())
            {
                _RemoveSetError();
                lblUserID.Text=_User.UserID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DataBack?.Invoke(this, _User);

            }
            else
            {
                MessageBox.Show("Data dose not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personCardWithFilter1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
