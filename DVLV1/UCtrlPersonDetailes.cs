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
        private int _PersonID = -1;
        public UCtrlPersonDetailes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        public void _LoudScreen(int ID)
        {
            _PersonID = ID;
            _LoadData();

        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person != null)
            {
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
                MessageBox.Show("some thining error happened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ParentForm.Close();
            }

        }
        private void UCtrlPersonDetailes_Load(object sender, EventArgs e)
        {

        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddUpdatePerson frmAddUpdatePerson = new FrmAddUpdatePerson(_PersonID);
            frmAddUpdatePerson.ShowDialog();
            _LoadData();
        }
    }
}
