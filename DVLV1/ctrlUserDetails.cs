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
    public partial class ctrlUserDetails : UserControl
    {
        clsUser user;
        public ctrlUserDetails()
        {
            InitializeComponent();
        }
        public void LoadInfo(int UserID)
        {
            user=clsUser.FindUserByID(UserID);

                uCtrlPersonDetailes1.LoadScreen(user.PersonID);
                lblUserID.Text = user.UserID.ToString();
                lblUsername.Text = user.UserName.ToString();
                lblIsActive.Text = (user.IsActive == true ? "Yse" : "No");
            
         

        }
        private void ctrlUserDetails_Load(object sender, EventArgs e)
        {
        }
    }
}
