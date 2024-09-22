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
    } 
}
