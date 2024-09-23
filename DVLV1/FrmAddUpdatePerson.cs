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
    public partial class FrmAddUpdatePerson : Form
    {
       int _PersonId;
        public delegate void DataBackEventHandler(object seder,clsPerson person);
        public event DataBackEventHandler DataBack;
        public FrmAddUpdatePerson()
        {
            InitializeComponent();
        }
        public FrmAddUpdatePerson(int Id)
        {
            InitializeComponent();
            uctrlAddUpdatePerson1.LoadScreen(Id);

        }
        private void uctrlAddUpdatePerson1_Load(object sender, EventArgs e)
        {
        }

        private void uctrlAddUpdatePerson1_OnPersonDataChanged(DVLD_businessLayer.clsPerson obj)
        {
            clsPerson person = (clsPerson)obj;
            DataBack?.Invoke(this, person);

        }

        private void FrmAddUpdatePerson_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FrmAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }
    }
}
