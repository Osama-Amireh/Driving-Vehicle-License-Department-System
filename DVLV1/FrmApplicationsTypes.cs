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
    public partial class FrmApplicationsTypes : Form
    {
        private int _RowIndex;
        public FrmApplicationsTypes()
        {
            InitializeComponent();
        }
        private void _RefreshTable()
        {
            dgvApplicaionsTypes.DataSource = clsApplicationsType.GetApllictions();
            lblRecords.Text = dgvApplicaionsTypes.RowCount.ToString();


        }
        private void FrmApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshTable();
            dgvApplicaionsTypes.Columns[0].Width = 100;
            dgvApplicaionsTypes.Columns[2].Width = 100;
            dgvApplicaionsTypes.Columns[1].Width = 300;
 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplictionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicaionsTypes.CurrentRow != null)
            {
                FrmEditApplicationType frmEditApplicationType = new FrmEditApplicationType((int)dgvApplicaionsTypes.CurrentRow.Cells[0].Value);
                frmEditApplicationType.DataBack += _DataBackUpdate;
                frmEditApplicationType.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Application Type to  Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        private void _DataBackUpdate(object sender, clsApplicationsType ApplicationType)
        {


            DataTable table=new DataTable();

            if (dgvApplicaionsTypes.DataSource is DataView dataView)
            {
                // If DataSource is a DataView, access the DataTable via its Table property
                table = dataView.Table;
            }
            else if (dgvApplicaionsTypes.DataSource is DataTable dataTable)
            {
                // If DataSource is a DataTable, assign it directly
                table = dataTable;
            }

            DataRow newRow = table.Rows[_RowIndex];
            // newRow["User ID"] = User.UserID;
            // newRow["Person ID"] = User.PersonID;
            //   newRow["Full Name"] = clsPerson.Find(User.PersonID).FullName;
            newRow["Title"] = ApplicationType.ApplicaionTitle;
            newRow["Fees"] = ApplicationType.Fee;
          
        }

        private void FrmApplicationsTypes_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        }

        private void dgvApplicaionsTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvApplicaionsTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _RowIndex = e.RowIndex;

        }
    }
}
