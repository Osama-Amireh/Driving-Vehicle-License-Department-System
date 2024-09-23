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
    public partial class FrmUserDetails : Form
    {
        public FrmUserDetails()
        {
            InitializeComponent();
        }
        public FrmUserDetails(int ID)
        {
            InitializeComponent();
            ctrlUserDetails1.LoadInfo(ID);
        }
        private void FrmUserDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
