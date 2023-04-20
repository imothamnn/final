using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_dental_cinic
{
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }

        private void appointmentTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Prescription_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.prescriptionTbl' table. You can move, or remove it, as needed.
            this.prescriptionTblTableAdapter.Fill(this.dataSet1.prescriptionTbl);
            // TODO: This line of code loads data into the 'dataSet1.TreatmentTbl' table. You can move, or remove it, as needed.
            this.treatmentTblTableAdapter.Fill(this.dataSet1.TreatmentTbl);
            // TODO: This line of code loads data into the 'dataSet1.AppointmentTbl' table. You can move, or remove it, as needed.
            this.appointmentTblTableAdapter.Fill(this.dataSet1.AppointmentTbl);
            fillpatient();
            string treatment = comboBox1.SelectedValue.ToString();
            treattxt.Text = treatment;
            // getprice();
            dataGridView1.DataSource = this.prescriptionTblTableAdapter.GetDataByDGV();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        
        

        private void fillpatient()
        {
            //comboBox1.DataSource = dataSet1.Tables["AppointmentTbl"];
            // comboBox1.ValueMember = "Patient";
            comboBox1.DataSource = dataSet1.Tables["AppointmentTbl"];
            comboBox1.DisplayMember = "patient";
            comboBox1.ValueMember = "treatment";

           


        }
        private void fillTreatmentTextBox(string patientName)
        {
            // Use a table adapter to retrieve the patient's treatment from the database
            // string treatment = Convert.ToString( this.appointmentTblTableAdapter.GetDataBypatname(patientName));
           // string treatment = Convert.ToString(this.appointmentTblTableAdapter.GetDataBypatname(comboBox1.SelectedValue.ToString()));

            // Display the patient's treatment in the textbox
            //treattxt.Text = treatment;
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // string patname = comboBox1.DisplayMember;
            //string displayMember = comboBox1.DisplayMember;
            // Assuming that the DisplayMember property of the combobox is set to "Name"
            /* object selectedItem = comboBox1.SelectedItem;
             if (selectedItem != null)
             {
                 PropertyInfo propertyInfo = selectedItem.GetType().GetProperty("patient");
                 if (propertyInfo != null)
                 {
                     string displayText = propertyInfo.GetValue(selectedItem).ToString();
                     // Do something with the display text
                     this.prescriptionTblTableAdapter.InsertQuerypresc(displayText, treattxt.Text, costtxt.Text, medtxt.Text, Convert.ToInt32(qnttxt.Text));
                     MessageBox.Show("Prescription Added Successfully");
                     dataGridView1.DataSource = this.prescriptionTblTableAdapter.GetDataByDGV();
                 }
             }*/
            // Assuming that the DisplayMember property of the combobox is set to "Name"


            DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string displayText = selectedRow["patient"].ToString();
                // do something with the display text
                this.prescriptionTblTableAdapter.InsertQuerypresc(displayText, treattxt.Text, costtxt.Text, medtxt.Text, Convert.ToInt32(qnttxt.Text));
                MessageBox.Show("Prescription Added Successfully");
                dataGridView1.DataSource = this.prescriptionTblTableAdapter.GetDataByDGV();
            }

            //string patname = comboBox1.SelectedItem.ToString();
           





        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string patientName = comboBox1.Text;

            // Fill the treatment textbox with the patient's treatment
            // fillTreatmentTextBox(patientName);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Your code that uses the selected item goes here
                string treatment = comboBox1.SelectedValue.ToString();
                treattxt.Text = treatment;
                string treatCost = "";
                DataView view = new DataView(dataSet1.TreatmentTbl);
                view.RowFilter = "treatname = '" + treatment + "'";
                if (view.Count > 0)
                {
                    treatCost = view[0]["treatcost"].ToString();
                }
                costtxt.Text = treatCost;
            }
            else
            {
                MessageBox.Show("error");
                // Handle the case where there is no selected item
            }
           
        }

        int key = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)  //to disable the row and column headers
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];


                // Your code here
                // comboBox1. = row.Cells[1].Value.ToString
                // string displayText = row.Cells[1].Value.ToString();
                /*string selectedValue = row.Cells[1].Value.ToString();

                // Populate the ComboBox with data from the DataSet
                this.prescriptionTblTableAdapter.Fill(this.dataSet1.prescriptionTbl);

                // Check if the selected value is present in the ComboBox items
                if (this.comboBox1.Items.Contains(selectedValue))
                {
                    // If the value is present, select it
                    this.comboBox1.SelectedItem = selectedValue;
                }
                else
                {
                    // If the value is not present, add it and select it
                    this.comboBox1.Items.Add(selectedValue);
                    this.comboBox1.SelectedItem = selectedValue;
                }*/


                /*  string displayText = row.Cells[1].Value.ToString();
                  comboBox1.DataSource = null; // clear the DataSource
                  comboBox1.Items.Clear(); // clear the items
                  comboBox1.Items.Add(displayText); // add the new value
                  comboBox1.SelectedIndex = 0; // select the added value*/

                // string displayText = row.Cells[1].Value.ToString();
                //correct code
                if (row.Cells[1].Value != null)
                {
                    string displayText = row.Cells[1].Value.ToString();

                    int index = comboBox1.FindStringExact(displayText);
                    if (index != -1)
                    {
                        comboBox1.SelectedIndex = index;
                    }
                }
               // comboBox1.SelectedValue = row.Cells[1].Value.ToString();
                treattxt.Text = row.Cells[2].Value.ToString();
                costtxt.Text = row.Cells[3].Value.ToString();
                medtxt.Text = row.Cells[4].Value.ToString();
                qnttxt.Text = row.Cells[5].Value.ToString();
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
                MessageBox.Show("Please Select Prescription");

            }
            else
            {
                try
                {
                    
                    this.prescriptionTblTableAdapter.DeleteQuerypres(key);
                    MessageBox.Show("Prescription Deleted successfully");
                    dataGridView1.DataSource = this.prescriptionTblTableAdapter.GetDataByDGV();
                    //clear();
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
                MessageBox.Show("Please Select Prescription");

            }
            else
            {
                try
                {

                    DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        string displayText = selectedRow["patient"].ToString();
                        // do something with the display text
                        this.prescriptionTblTableAdapter.UpdateQuerypresc(displayText, treattxt.Text, costtxt.Text, medtxt.Text, Convert.ToInt32(qnttxt.Text),key);
                        MessageBox.Show("Prescription updated Successfully");
                        dataGridView1.DataSource = this.prescriptionTblTableAdapter.GetDataByDGV();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure the change is on a valid row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string cellValue = row.Cells[e.ColumnIndex].Value.ToString();
                comboBox1.SelectedItem = cellValue;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Treatment treat = new Treatment();
            treat.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
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
