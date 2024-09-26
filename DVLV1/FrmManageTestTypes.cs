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
    
    public partial class FrmManageTestTypes : Form
    {
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAllTypes();
            lblRecords.Text=dgvTestTypes.RowCount.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {


            _RefreshData();
            dgvTestTypes.Columns[0].Width = 100;
            dgvTestTypes.Columns[1].Width = 150;
            dgvTestTypes.Columns[2].Width = 300;
            dgvTestTypes.Columns[3].Width = 80;
        }
        private int _RowIndex;
        private void UpdateTestDataBack(object seder, clsTestTypes TestType)
        {
            DataTable table = new DataTable();

            if (dgvTestTypes.DataSource is DataView dataView)
            {
                // If DataSource is a DataView, access the DataTable via its Table property
                table = dataView.Table;
            }
            else if (dgvTestTypes.DataSource is DataTable dataTable)
            {
                // If DataSource is a DataTable, assign it directly
                table = dataTable;
            }

            DataRow newRow = table.Rows[_RowIndex];
            // newRow["User ID"] = User.UserID;
            // newRow["Person ID"] = User.PersonID;
            //   newRow["Full Name"] = clsPerson.Find(User.PersonID).FullName;
            newRow["Title"] = TestType.TestName;
            newRow["Fees"] = TestType.TestFee;
            newRow["Description"] = TestType.Description;

        }
        private void editTypeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.CurrentRow != null)
            {
                FrmEditTypeTest frmEditTypeTest = new FrmEditTypeTest((int)dgvTestTypes.CurrentRow.Cells[0].Value);
                frmEditTypeTest.DataBack += UpdateTestDataBack;
                frmEditTypeTest.ShowDialog();
            }
            else
            {
                
                    MessageBox.Show("Please select a Test Type to  Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
            }
        }

        private void dgvTestTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTestTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _RowIndex=e.RowIndex;
        }
    }
}
