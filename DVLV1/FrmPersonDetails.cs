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
            uCtrlPersonDetailes1._LoudScreen(ID);
        }
    }
}
