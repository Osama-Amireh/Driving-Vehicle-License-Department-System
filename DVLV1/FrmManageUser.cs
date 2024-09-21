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
    public partial class FrmManageUser : Form
    {
        public FrmManageUser()
        {
            InitializeComponent();
        }
        private void _RefreshUsersData()
        {
            dgvUsers.DataSource=clsUser.GetAllUers();
            lblNumRecords.Text=dgvUsers.RowCount.ToString();
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
        }
    }
}
