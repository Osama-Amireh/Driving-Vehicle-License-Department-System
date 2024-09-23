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
    public partial class PersonCardWithFilter : UserControl
    {
        public int PersonID = -1;
        public PersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1 && clsValidate.ValidateInteger(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void LoadPersonInfo(int ID)
        {
            uCtrlPersonDetailes1.LoadScreen(ID);
            uCtrlPersonDetailes1._PersonID = ID;
            PersonID = ID;

        }
        public void LoadPersonInfo(string NationaNom)
        {
            uCtrlPersonDetailes1._LoudScreen(NationaNom);
            PersonID = uCtrlPersonDetailes1._PersonID;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                       LoadPersonInfo(txtBoxFiter.Text);
                        break;
                    }
                case 1:
                    {
                        int i = Convert.ToInt32(txtBoxFiter.Text);
                        LoadPersonInfo(i);
                        break;
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddUpdatePerson frmAddUpdatePerson = new FrmAddUpdatePerson();
            frmAddUpdatePerson.DataBack += PersnoDataBack;
            frmAddUpdatePerson.ShowDialog();
        }
        private void _FillDataBackToFiled(clsPerson Person)
        {
            cbFilter.SelectedIndex = 1;
            txtBoxFiter.Text = Person.PersonID.ToString();
            LoadPersonInfo(Person.PersonID);

        }
        private void PersnoDataBack(object sender,clsPerson Person)
        {
            _FillDataBackToFiled(Person);
        }
        private void PersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }
        public void FilterFocus()
        {
            groupBox1.Focus();

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFiter.Clear();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
