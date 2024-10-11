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
    public partial class FrmNewLocalLicenseApplication : Form
    {
        clsPerson _Person;
        public enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;
        public FrmNewLocalLicenseApplication()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }
        private void _FillDataToCombmBox()
        {
            DataTable table = clsLicenseClasses.GetAllLicenseClass();
            foreach (DataRow row in table.Rows)
            {

                CbClass.Items.Add(row["ApplicaionTypeTitle"]);

            }
            CbClass.SelectedIndex=0;
        }
        private void _RefreshData()
        {
            if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Update Local Driving license Application";
                this.Text = "Update Local Driving license Application";
                TpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                lblTitle.Text = "New Local Driving license Application";
                this.Text = "New Local Driving license Application";
                TpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
                _Person = new clsPerson();
                personCardWithFilter1.FilterFocus();
            }
        }
        private void FrmNewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshData();

        }

        private void TpApplicationInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (enMode.Update == _Mode)
            {
                btnSave.Enabled = true;
                TpApplicationInfo.Enabled = true;
                TcNewlicense.SelectedTab = TcNewlicense.TabPages["TpApplicationInfo"];
                return;
            }

            if (personCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                TpApplicationInfo.Enabled = true;
                TcNewlicense.SelectedTab = TcNewlicense.TabPages["TpApplicationInfo"];
                lblCreatedBy.Text=clsGlobal.CurrentUser.UserName;
                lblData.Text = DateTime.Now.ToString();
                CbClass.SelectedIndex = 3;

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personCardWithFilter1.FilterFocus();

            }
        }
    }
}
