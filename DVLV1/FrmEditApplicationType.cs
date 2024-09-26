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
    public partial class FrmEditApplicationType : Form
    {
        clsApplicationsType _ApplicationsType;
       private int _ApplicationID;
        public delegate void DataBackEventHandler(object seder, clsApplicationsType ApplicationsType);
        public event DataBackEventHandler DataBack;

        public FrmEditApplicationType()
        {
            InitializeComponent();
        }
        public FrmEditApplicationType(int ID)
        {
            InitializeComponent();
            _ApplicationID = ID;
        }
        private bool _IsSaved = false;

        private bool _Valid()
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtboxTitle.Text))
            {
                errorProvider1.SetError(txtboxTitle, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtBoxFee.Text))
            {
                errorProvider2.SetError(txtBoxFee, "Required");
                IsValid = false;

            }
   


            return IsValid;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationsType.ID = Convert.ToInt32( lblID.Text);
            _ApplicationsType.ApplicaionTitle = txtboxTitle.Text;
            _ApplicationsType.Fee=Convert.ToDecimal(txtBoxFee.Text);
            if(_Valid())
           if ( _ApplicationsType.Save())
            {
                MessageBox.Show("Data Saved successfully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataBack?.Invoke(this, _ApplicationsType);

            }
            else
            {
                MessageBox.Show(" Data Dosen`t Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationsType = clsApplicationsType.Find(_ApplicationID);
            lblID.Text = _ApplicationsType.ID.ToString();
            txtboxTitle.Text = _ApplicationsType.ApplicaionTitle;
            txtBoxFee.Text= _ApplicationsType.Fee.ToString();
        }
    }
}
