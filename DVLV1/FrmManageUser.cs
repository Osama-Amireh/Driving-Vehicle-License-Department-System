using DVLD_businessLayer;
using DVLDClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLV1
{
    public partial class FrmManageUser : Form
    {
        DataView dv = clsUser.GetAllUers().AsDataView();
        int _RowIndex;
        public FrmManageUser()
        {
            InitializeComponent();
        }
        private void _RefreshUsersData()
        {
            dgvUsers.DataSource = clsUser.GetAllUers();
            lblNumRecords.Text = dgvUsers.RowCount.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmManageUser_Load(object sender, EventArgs e)
        {
            _RefreshUsersData();
            cbFilterUser.SelectedIndex = 0;
            dgvUsers.Columns[0].Width = 110;
            dgvUsers.Columns[1].Width = 120;
            dgvUsers.Columns[2].Width = 350;
            dgvUsers.Columns[3].Width = 120;
            dgvUsers.Columns[4].Width = 120;

        }
        private void _RemoveFilterFromData()
        {
            dv.RowFilter = "";
            dgvUsers.DataSource = dv;
            lblNumRecords.Text = dgvUsers.RowCount.ToString();
        }
        private void btcClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterUser.SelectedIndex)
            {
                case 0:
                    {
                        txtBoxFilter.Visible = false; CbIsActive.Visible = false; _RemoveFilterFromData(); break;
                    };
                case 5:
                    {
                        CbIsActive.Visible = true;
                        txtBoxFilter.Visible = false; _RemoveFilterFromData(); break;

                    }
                default:
                    {
                        CbIsActive.Visible = false;
                        txtBoxFilter.Visible = true; txtBoxFilter.Clear(); break;

                    }
            }
        }

        private void txtBoxFilter_TextChanged(object sender, EventArgs e)
        {


            if (txtBoxFilter.TextLength > 0)
            {



                switch (cbFilterUser.SelectedIndex)
                {
                    case 1:
                        {
                            dv.RowFilter = "[User ID]=" + txtBoxFilter.Text.Trim() ;
                            dgvUsers.DataSource = dv;
                            lblNumRecords.Text = dgvUsers.RowCount.ToString();
                            break;
                        }
                    case 2:
                        {
                            dv.RowFilter = "[User Name] Like '%" + txtBoxFilter.Text.Trim() + "%'";
                            dgvUsers.DataSource = dv;
                            lblNumRecords.Text = dgvUsers.RowCount.ToString();
                            break;
                        }
                    case 3:
                        {
                            dv.RowFilter = "[Person ID] =" + txtBoxFilter.Text.Trim() ;
                            dgvUsers.DataSource = dv;
                            lblNumRecords.Text = dgvUsers.RowCount.ToString();
                            break;
                        }
                    case 4:
                        {
                            dv.RowFilter = "[Full Name] Like '%" + txtBoxFilter.Text.Trim() + "%'";
                            dgvUsers.DataSource = dv;
                            lblNumRecords.Text = dgvUsers.RowCount.ToString();
                            break;
                        }

                    case 5:
                        {
                            cbFilterUser.Visible = false;
                            CbIsActive.Visible = true;
                            
                            break;
                        }
                }
            
                
            }
            else
            {
                _RemoveFilterFromData();
            }
        }

        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbIsActive.SelectedIndex)
            {
                case 0:
                    {
                        _RemoveFilterFromData();
                        break;
                    }
                case 1:
                    {
                        dv.RowFilter = "[Is Active]='True'";
                        dgvUsers.DataSource = dv;
                        lblNumRecords.Text = dgvUsers.RowCount.ToString();
                        break;
                    }
                case 2:
                    {
                        dv.RowFilter = "[Is Active]='false'";
                        dgvUsers.DataSource = dv;
                        lblNumRecords.Text = dgvUsers.RowCount.ToString();
                        break;
                    }
            }
        }

        private void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(clsValidate.ValidateInteger(e.KeyChar)&&(cbFilterUser.SelectedIndex==1||cbFilterUser.SelectedIndex==3))
            {
                e.Handled = true;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAddUpdateUser frmAddUpdateUser = new FrmAddUpdateUser();
            frmAddUpdateUser.DataBack += AddNewUserBack;
            frmAddUpdateUser.ShowDialog();
        }
        private void AddNewUserBack(object sender,clsUser User)
        {

            DataTable table = ((DataView)dgvUsers.DataSource).Table;
            DataRow newRow = table.NewRow();
            newRow["User ID"] = User.UserID;
            newRow["Person ID"] = User.PersonID;
            newRow["Full Name"] = clsPerson.Find(User.PersonID).FullName;
            newRow["User Name"] = User.UserName;
            newRow["Is Active"] = User.IsActive;
            table.Rows.Add(newRow);

        }
        private void UpdateUserBack(object sender, clsUser User)
        {
            DataTable table1 = ((DataView)dgvUsers.DataSource).Table;
           
            DataRow newRow = table1.Rows[_RowIndex];
           // newRow["User ID"] = User.UserID;
           // newRow["Person ID"] = User.PersonID;
         //   newRow["Full Name"] = clsPerson.Find(User.PersonID).FullName;
            newRow["User Name"] = User.UserName;
            newRow["Is Active"] = User.IsActive;

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                FrmAddUpdateUser frmAddUpdateUser = new FrmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
                frmAddUpdateUser.DataBack += UpdateUserBack;

                frmAddUpdateUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a person to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _RowIndex = e.RowIndex;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)

                {

                    //Perform Delele and refresh
                    if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("User Deleted Successfully.", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvUsers.Rows.RemoveAt(_RowIndex);

                    }

                    else
                        MessageBox.Show("Can not Delete This User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Please select a User to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implementated yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implementated yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddUpdateUser frmAddUpdateUser = new FrmAddUpdateUser();
            frmAddUpdateUser.DataBack += AddNewUserBack;
            frmAddUpdateUser.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                FrmUserDetails frmUserDetails = new FrmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
                frmUserDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                FrmChangePassword frmChangePassword = new FrmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
                frmChangePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    } 
}
