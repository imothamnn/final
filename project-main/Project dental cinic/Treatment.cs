using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_dental_cinic
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void treatmentTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.treatmentTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Treatment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TreatmentTbl' table. You can move, or remove it, as needed.
            this.treatmentTblTableAdapter.Fill(this.dataSet1.TreatmentTbl);
            treatmentTblDataGridView.DataSource = this.treatmentTblTableAdapter.GetDataDGV();

        }
        private void clear()
        {
            nametxt.Clear();
            desctxt.Clear();
            costtxt.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var x = this.treatmentTblTableAdapter.GetDataByTreat(nametxt.Text);
            if(x.Count == 0)
            {
                this.treatmentTblTableAdapter.InsertQueryTreat(nametxt.Text, Convert.ToInt32(costtxt.Text), desctxt.Text);
                MessageBox.Show("Treatment Added successfully");
                //.DataSource = this.patientTblTableAdapter.GetDataDGV();
                treatmentTblDataGridView.DataSource = this.treatmentTblTableAdapter.GetDataDGV();

            }
            else
            {
                MessageBox.Show("Treatment already exists");
            }
        }

        int key = 0;
        private void treatmentTblDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)   //to disable the row and column headers
            {
                DataGridViewRow row = this.treatmentTblDataGridView.Rows[e.RowIndex];
                nametxt.Text = row.Cells[1].Value.ToString();
                costtxt.Text = row.Cells[2].Value.ToString();
                desctxt.Text = row.Cells[3].Value.ToString();
                if (nametxt.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }

            } 
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select Treatment");

            }
            else
            {
                try
                {
                    // this.patientTblTableAdapter.DeleteQuerypat(key);
                    this.treatmentTblTableAdapter.DeleteQueryTreat(key);
                    MessageBox.Show("Treatment Deleted successfully");
                    treatmentTblDataGridView.DataSource = this.treatmentTblTableAdapter.GetDataDGV();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select Treatment");

            }
            else
            {
                try
                {
                    // this.patientTblTableAdapter.DeleteQuerypat(key);
                    this.treatmentTblTableAdapter.UpdateQueryTreat(nametxt.Text,Convert.ToInt32(costtxt.Text),desctxt.Text,key);
                    MessageBox.Show("Treatment updated successfully");
                    treatmentTblDataGridView.DataSource = this.treatmentTblTableAdapter.GetDataDGV();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Prescription pres = new Prescription();
            pres.Show();
            this.Hide();
        }
    }
}
