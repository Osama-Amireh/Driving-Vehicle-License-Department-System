using DVLD_businessLayer;
using DVLV1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_businessLayer.clsPerson;

namespace DVLV1
{
    public partial class UctrlAddUpdatePerson : UserControl
    {
        clsPerson _Person = new clsPerson();
        private int _PersonID = -1;
        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode=enMode.AddNew;
        public int PersonID { get { return _PersonID; } }
        public UctrlAddUpdatePerson()
        {
            InitializeComponent();
           
        }
        

        private void _FillCountriesInComoboBox()
        {

            DataTable dtCountries = clsCountries.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                comboBox1.Items.Add(row["CountryName"]);

            }

        }
        public void LoadScreen(int ID)
        {
            _PersonID = ID;
        }
        private void _LoadData()
        {
            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-16);
            _FillCountriesInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                comboBox1.SelectedIndex = 0;
                llRemoveImage.Visible = false;
                _Person = new clsPerson();
                return;

            }
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This Person dose not exsist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMode.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();
            txtboxFirst.Text = _Person.FirstName;
            txtboxSecond.Text = _Person.SecondName;
            txtboxThird.Text = _Person.ThirdName;
            txtboxLast.Text = _Person.LastName;
            txtboxNationalNo.Text = _Person.NationalNo;
            txtboxAddres.Text = _Person.Address;
            txtBoxEmail.Text = _Person.Email;
            llRemoveImage.Visible = (_Person.ImagePath != "");
            dateTimePicker1.Value = _Person.BirthOfDate;
             txtBoxPhone.Text = _Person.Phone;
            comboBox1.SelectedIndex = comboBox1.FindString(clsCountries.Find(_Person.Nationality).CountryName);
            if (_Person.ImagePath != "")
            {
                picboxGender.Load(_Person.ImagePath);
            }

        }
  

 
        private void txtBoxEmail_TextChanged(object sender, EventArgs e)
        {


        }
        private bool _ValidInfo()
        {
            bool IsValid = true;
            if (!string.IsNullOrEmpty(txtBoxEmail.Text) && ((txtBoxEmail.Text.Contains('@') == false || txtBoxEmail.Text.Contains(".com") == false)))
            {
                errorProvider1.SetError(txtBoxEmail, "Must Enter Valid Email");
                IsValid = false;
            }
            else if (enMode.AddNew==_Mode&&!string.IsNullOrEmpty(txtBoxEmail.Text) && (clsPerson.IsEmailExisit(txtBoxEmail.Text.Trim()) == true))
            {
                errorProvider1.SetError(txtBoxEmail, "This Email already Exisit");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtboxFirst.Text))
            {
                errorProvider2.SetError(txtboxFirst, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtboxSecond.Text))
            {
                errorProvider3.SetError(txtboxSecond, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtboxLast.Text))
            {
                errorProvider4.SetError(txtboxLast, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtBoxPhone.Text))
            {
                errorProvider5.SetError(txtBoxPhone, "Required");
                IsValid = false;
            }
            else if (txtBoxPhone.TextLength < 10)
            {
                errorProvider5.SetError(txtBoxPhone, "Must Enter Valid Phone");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtboxAddres.Text))
            {
                errorProvider6.SetError(txtboxAddres, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtboxNationalNo.Text))
            {
                errorProvider7.SetError(txtboxNationalNo, "Required");
                IsValid = false;
            }
            else if (enMode.AddNew == _Mode && clsPerson.IsNationalNoExisit(txtboxNationalNo.Text) == true)
            {
                errorProvider7.SetError(txtboxNationalNo, "This National Number already Exisit");
                IsValid = false;
            }
            return IsValid;

        }
        private void _FillDataToPerson()
        {
            _Person.FirstName = txtboxFirst.Text.Trim();
            _Person.LastName = txtboxLast.Text.Trim();
            _Person.SecondName = txtboxSecond.Text.Trim();
            if (string.IsNullOrEmpty(txtboxThird.Text) == false)
            {
                _Person.ThirdName = txtboxThird.Text.Trim();
            }
            _Person.NationalNo = txtboxNationalNo.Text.Trim();
            _Person.Nationality = clsCountries.Find(comboBox1.Text).CountryID;
            _Person.Phone = txtBoxPhone.Text.Trim();
            if (rdbMale.Checked)
            {
                _Person.Gender = 0;
            }
            else
            {
                _Person.Gender = 1;
            }
            if (string.IsNullOrEmpty(txtBoxEmail.Text) == false)
            {
                _Person.Email = txtBoxEmail.Text.Trim();
            }
            _Person.BirthOfDate = dateTimePicker1.Value;
            if (picboxGender.ImageLocation != null)
                _Person.ImagePath = picboxGender.ImageLocation.Trim();
            else
                _Person.ImagePath = "";
           _Person.Address= txtboxAddres.Text;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            bool IsValid = _ValidInfo();




            if (IsValid == true)
            {
                _FillDataToPerson();
                if (_Person.Save())
                {
                    MessageBox.Show("Data Saved Successfully.");
                    _Mode = enMode.Update;
                    lblMode.Text = "Update Person";
                    lblPersonID.Text = _Person.PersonID.ToString().Trim();

                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");

         

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }
         
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != picboxGender.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch
                    {

                    }
                }
                if (picboxGender.ImageLocation != null)
                {
                    string SourceImageFile = picboxGender.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picboxGender.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void llimage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                picboxGender.Load(selectedFilePath);
                _HandlePersonImage();
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void rdbMale_CheckedChanged_1(object sender, EventArgs e)
        {
            picboxGender.Image = Resources.man__1_;

        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            picboxGender.Image = Resources.user_female;

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
