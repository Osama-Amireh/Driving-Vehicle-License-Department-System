using DVLD_businessLayer;
using DVLV1.Properties;
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

    public partial class UCtrlPersonDetailes : UserControl
    {
        private clsPerson _Person;
        public int _PersonID = -1;
        private string _NationalNo = "";
        public UCtrlPersonDetailes()
        {
            InitializeComponent();
            llEditInfo.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.ParentForm.Close();
        }
        public void LoadScreen(int ID)
        {
            _PersonID = ID;
            _LoadDataByPersonID();

        }
        public void _LoudScreen(string NationalNo)
        {
            _NationalNo = NationalNo;
            _LoadDataByNationalNo();

        }
        private void _LoadDataByNationalNo()
        {
            _Person = clsPerson.Find(_NationalNo);
            if (_Person != null)
            {
                llEditInfo.Enabled = true;
                _PersonID = _Person.PersonID;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNo;
                lblGender.Text = (_Person.Gender == 0 ? "Male" : "Female");
                lblCountry.Text = clsCountries.Find(_Person.Nationality).CountryName;
                lblDateOfBirth.Text = _Person.BirthOfDate.ToString("dd/MM/yyyy");
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblAddress.Text = _Person.Address;
                if (_Person.ImagePath != "")
                {
                    picGender.Load(_Person.ImagePath);
                }
                else if (_Person.Gender == 1)
                {
                    picGender.Image = Resources.user_female;

                }
                else
                {
                    picGender.Image = Resources.man__1_;

                }
            }
            else
            {
                MessageBox.Show("No Person National NO. = " + _NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                llEditInfo.Enabled = false;
            }


        }
        private void _LoadDataByPersonID()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person != null)
            {
                _PersonID=_Person.PersonID;
                llEditInfo.Enabled = true;

                lblPersonID.Text = _PersonID.ToString();
                lblName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNo;
                lblGender.Text = (_Person.Gender == 0 ? "Male" : "Female");
                lblCountry.Text = clsCountries.Find(_Person.Nationality).CountryName;
                lblDateOfBirth.Text = _Person.BirthOfDate.ToString("dd/MM/yyyy");
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblAddress.Text = _Person.Address;
                if (_Person.ImagePath != "")
                {
                    picGender.Load(_Person.ImagePath);
                }
                else if (_Person.Gender == 1)
                {
                    picGender.Image = Resources.user_female;

                }
                else
                {
                    picGender.Image = Resources.man__1_;

                }
            }
            else
            {
                MessageBox.Show("No Person With ID= " + _PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _PersonID = -1;
                llEditInfo.Enabled = false;
            }


        }
        private void UCtrlPersonDetailes_Load(object sender, EventArgs e)
        {

        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID != -1)
            {
                llEditInfo.Enabled = true;

                FrmAddUpdatePerson frmAddUpdatePerson = new FrmAddUpdatePerson(_PersonID);
                frmAddUpdatePerson.ShowDialog();
                _LoadDataByPersonID();
            }
            else
            {
                llEditInfo.Enabled=false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
