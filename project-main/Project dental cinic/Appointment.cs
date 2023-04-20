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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        private void fillpatient()
        {


            
            comboBox1.DataSource = dataSet1.Tables["PatientTbl"];
            comboBox1.ValueMember = "PatName"; // Specify the column name to use as the value for each item

        }
        private void filltreatment()
        {
            comboBox2.DataSource = dataSet1.Tables["TreatmentTbl"];
            comboBox2.ValueMember = "TreatName";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Prescription pres = new Prescription();
            pres.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime appdate = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
            this.appointmentTblTableAdapter.InsertQueryapp(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), appdate);
            MessageBox.Show("Appoinment Recorded Successfully");
            dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByDGV();
            clear();
        }

        private void treatmentTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.treatmentTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.AppointmentTbl' table. You can move, or remove it, as needed.
            this.appointmentTblTableAdapter.Fill(this.dataSet1.AppointmentTbl);
            // TODO: This line of code loads data into the 'dataSet1.PatientTbl' table. You can move, or remove it, as needed.
            this.patientTblTableAdapter.Fill(this.dataSet1.PatientTbl);
            // TODO: This line of code loads data into the 'dataSet1.TreatmentTbl' table. You can move, or remove it, as needed.
            this.treatmentTblTableAdapter.Fill(this.dataSet1.TreatmentTbl);
            fillpatient();
            filltreatment();
            dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByDGV();

        }
        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  //to disable the row and column headers
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.SelectedValue = row.Cells[1].Value.ToString();
                comboBox2.SelectedValue = row.Cells[2].Value.ToString();
                string pat = row.Cells[1].Value.ToString();
                if (pat == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select Appointment");

            }
            else
            {
                try
                {
                    this.appointmentTblTableAdapter.DeleteQueryApp(key);
                    MessageBox.Show("Appointment Deleted successfully");
                    dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByDGV();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select Appointment");

            }
            else
            {
                try
                {
                    DateTime appdate = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                    this.appointmentTblTableAdapter.UpdateQueryApp(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), appdate, key);
                    MessageBox.Show("Appointment Updated successfully");
                    dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByDGV();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void filter()
        {

            dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByfilter(filtertxt.Text);

        }
        private void filtertxt_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.appointmentTblTableAdapter.GetDataByDGV();
            filtertxt.Text = "Filter By Patient Name";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Treatment treat = new Treatment();
            treat.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
