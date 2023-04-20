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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.userTbl' table. You can move, or remove it, as needed.
            this.userTblTableAdapter.Fill(this.dataSet1.userTbl);
            dataGridView1.DataSource = this.userTblTableAdapter.GetDataByDGV();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }
        private void clear()
        {
            nametxt.Clear();
            phonetxt.Clear();
            passwordtxt.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = this.userTblTableAdapter.GetDataByPhone(phonetxt.Text);
            if (x.Count == 0)
            {
                this.userTblTableAdapter.InsertQueryUser(nametxt.Text, passwordtxt.Text, phonetxt.Text);
                MessageBox.Show("User Created Successfully");
                dataGridView1.DataSource = this.userTblTableAdapter.GetDataByDGV();
                clear();
            }
            else
            {
                MessageBox.Show("User already exists");
            }
        }

        int key = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  //to disable the row and column headers
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                nametxt.Text = row.Cells[1].Value.ToString();
                phonetxt.Text = row.Cells[3].Value.ToString();
                passwordtxt.Text = row.Cells[2].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select User");

            }
            else
            {
                try
                {
                    this.userTblTableAdapter.DeleteQueryuser(key);
                    MessageBox.Show("User Deleted successfully");
                    dataGridView1.DataSource = this.userTblTableAdapter.GetDataByDGV();
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
                MessageBox.Show("Please Select User");

            }
            else
            {
                try
                {
                    this.userTblTableAdapter.UpdateQueryuser(nametxt.Text, passwordtxt.Text, phonetxt.Text, key);
                    MessageBox.Show("User updated successfully");
                    dataGridView1.DataSource = this.userTblTableAdapter.GetDataByDGV();
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
    }
}
