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
    public partial class FrmEditTypeTest : Form
    {
        public delegate void DataBackEventHandler(object seder, clsTestTypes TestType);
        public event DataBackEventHandler DataBack;
        public FrmEditTypeTest()
        {
            InitializeComponent();
        }
        public FrmEditTypeTest(int TestID)
        {
            InitializeComponent();
            _ID = TestID;
        }
        clsTestTypes _types;
        private int _ID;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditTypeTest_Load(object sender, EventArgs e)
        {
            _types = clsTestTypes.Find(_ID);
            lblID.Text=_types.TestID.ToString();
            txtBoxTitle.Text=_types.TestName.ToString();
            txtBoxDesc.Text=_types.Description.ToString();
            txtBoxFee.Text=_types.TestFee.ToString();

        }
        private bool _Valid()
        {
            bool IsValid=true;
            if(string.IsNullOrEmpty(txtBoxTitle.Text))
            {
                errorProvider1.SetError(txtBoxTitle, "Required");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtBoxDesc.Text))
            {
                errorProvider2.SetError(txtBoxDesc, "Required");
                IsValid = false;

            }
            if (string.IsNullOrEmpty(txtBoxFee.Text))
            {
                errorProvider3.SetError(txtBoxFee, "Required");
                IsValid = false;

            }


            return IsValid;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _types.TestName= txtBoxTitle.Text;
            _types.Description= txtBoxDesc.Text;
            _types.TestFee=Convert.ToDecimal(txtBoxFee.Text);
            if(_Valid())
            if (_types.save())
            {
              
                    MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(this, _types);

            }
            else
            {
                MessageBox.Show(" Data Dosen`t Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
