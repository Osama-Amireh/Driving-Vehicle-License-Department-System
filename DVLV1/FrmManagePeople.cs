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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DVLDClasses;

namespace DVLV1
{
    public partial class FrmManagePeople : Form
    {
        public FrmManagePeople()
        {
            InitializeComponent();
        }
        DataView dv = clsPerson.GetAllPeople().AsDataView();
        private void _RefreshPeopleData()
        {
            dgvListPeople.DataSource = clsPerson.GetAllPeople();
            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleData();
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void txtboxFind_TextChanged(object sender, EventArgs e)
        {

        }
        private void _RemoveFilterFromData()
        {
            dv.RowFilter = "";
            dgvListPeople.DataSource = dv;
            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddUpdatePerson frm = new FrmAddUpdatePerson();
            frm.DataBack += _DataBackAddNewPerson;
            frm.ShowDialog();
          //  _RefreshPeopleData();
        }
        private void _DataBackAddNewPerson(object sender, clsPerson person)
        {
            DataTable table = ((DataView)dgvListPeople.DataSource).Table;
            DataRow newRow = table.NewRow();
            newRow["Person ID"] = person.PersonID;
            newRow["NationalNo"] = person.NationalNo;
            newRow["First Name"] = person.FirstName;
            newRow["Second Name"] = person.SecondName;
            newRow["Third Name"] = person.ThirdName;
            newRow["Last Name"] = person.LastName;
            newRow["Gender"] = person.Gender;
            newRow["Date of Birth"] = person.BirthOfDate.ToString("dd/MM/yyyy");
            newRow["Nationality"] =clsCountries.Find( person.Nationality).CountryName;
            newRow["phone"] = person.Phone;
            newRow["Email"] = person.Email;

            table.Rows.Add(newRow);
            
        }
            private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblNumerRecords_Click(object sender, EventArgs e)
        {

        }
        int _RowIndex;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListPeople.CurrentRow != null)
            {
                FrmAddUpdatePerson frm = new FrmAddUpdatePerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
                frm.DataBack += _DataBackUdatePersonPerson;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a person to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }           // _RefreshPeopleData();
        }
        private void _DataBackUdatePersonPerson(object sender, clsPerson person)
        {
           // dgvListPeople.Columns["Gender"].ReadOnly = false;

            DataTable table1 = ((DataView)dgvListPeople.DataSource).Table;
            table1.Columns["Gender"].ReadOnly = false;
            table1.Columns["Nationality"].ReadOnly = false;
            table1.Columns["Date of Birth"].ReadOnly = false;

            DataRow newRow = table1.Rows[_RowIndex];
            //newRow["Person ID"] = person.PersonID;
            newRow["NationalNo"] = person.NationalNo;
            newRow["First Name"] = person.FirstName;
            newRow["Second Name"] = person.SecondName;
            newRow["Third Name"] = person.ThirdName;
            newRow["Last Name"] = person.LastName;
            newRow["Gender"] = (person.Gender==0)?"Male":"Female";
            newRow["Date of Birth"] = person.BirthOfDate.ToString("dd/MM/yyyy");
            newRow["Nationality"] = clsCountries.Find(person.Nationality).CountryName;
            newRow["phone"] = person.Phone;
            newRow["Email"] = person.Email;


        }
        private void dgvListPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: { 
                        txtboxFind.Visible = false; _RemoveFilterFromData(); break;
                            };
                default: { 
                        txtboxFind.Visible = true; txtboxFind.Clear(); break; 
                        
                    }


            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListPeople.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete Person [" + dgvListPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)

                {

                    //Perform Delele and refresh
                    if (clsPerson.DeletePerson((int)dgvListPeople.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Person Deleted Successfully.", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvListPeople.Rows.RemoveAt(_RowIndex);

                    }

                    else
                        MessageBox.Show("Can not Delete This Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Please select a person to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtboxFind_TextChanged_1(object sender, EventArgs e)
        {


            if (txtboxFind.Text.Length > 0)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 1:
                        {
                            dv.RowFilter = "[Person ID]=" + txtboxFind.Text;
                            dgvListPeople.DataSource = dv;
                            break;
                        }
                    case 2:
                        {
                            dv.RowFilter = "[First Name] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 3:
                        {
                            dv.RowFilter = "[Second Name] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 4:
                        {
                            dv.RowFilter = "[Third Name] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }

                    case 5:
                        {
                            dv.RowFilter = "[Last Name] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 6:
                        {
                            dv.RowFilter = "[NationalNo] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 7:
                        {
                            dv.RowFilter = "[Nationality]='" + txtboxFind.Text+"'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 8:
                        {
                            dv.RowFilter = "[Gender]='" + txtboxFind.Text.Trim()+"'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 9:
                        {
                            dv.RowFilter = "[Email] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }
                    case 10:
                        {
                            dv.RowFilter = "[Phone] Like '%" + txtboxFind.Text.Trim() + "%'";
                            dgvListPeople.DataSource = dv;
                            lblNumerRecords.Text = dgvListPeople.RowCount.ToString();
                            break;
                        }

                }
            }
            else
            {
                _RemoveFilterFromData();

            }
        }

        private void txtboxFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(clsValidate.ValidateInteger(e.KeyChar) && comboBox1.SelectedIndex == 1)
            {
                e.Handled = true;

            }
     
       
        }

        private void dgvListPeople_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _RowIndex=e.RowIndex;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void personDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListPeople.CurrentRow != null)
            {
                FrmPersonDetails frmPersonDetails = new FrmPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
                frmPersonDetails.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please select a person to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
                FrmAddUpdatePerson frm = new FrmAddUpdatePerson();
                frm.DataBack += _DataBackAddNewPerson;
                frm.ShowDialog();
          
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implementated yet","Not Ready",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implementated yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
