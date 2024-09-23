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
    public partial class FrmPersonDetails : Form
    {
        private int _PersonID;
        public FrmPersonDetails()
        {
            InitializeComponent();
        }
        public FrmPersonDetails(int ID)
        {
            InitializeComponent();
            uCtrlPersonDetailes1.LoadScreen(ID);
        }
        public FrmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            uCtrlPersonDetailes1._LoudScreen(NationalNo);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
