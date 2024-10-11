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
    public partial class FrmMain : Form
    {
        FrmLogin _frmLogin;
        public FrmMain()
        {
            InitializeComponent();
        }
        public FrmMain(FrmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople Form = new FrmManagePeople();
            Form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUser users = new FrmManageUser();
            users.ShowDialog();
        }

        private void accountSettngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserDetails Form = new FrmUserDetails(clsGlobal.CurrentUser.UserID);
            Form.ShowDialog();


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword(clsGlobal.CurrentUser.UserID);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser=null;
            _frmLogin.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(clsGlobal.CurrentUser!=null)
            {
                Application.Exit();

            }
        }

        private void manageApplicationsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmApplicationsTypes frmApplicationsTypes = new FrmApplicationsTypes();
            frmApplicationsTypes.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmManageTestTypes frm
                = new FrmManageTestTypes();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmNewLocalLicenseApplication frm=new FrmNewLocalLicenseApplication();
            frm.ShowDialog();

        }

        private void localDreivingApplicationLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
