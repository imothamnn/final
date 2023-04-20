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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Adminlogin log = new Adminlogin();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = this.userTblTableAdapter.GetDataBylogin(textBox2.Text);
            if(x.Count == 0)
            {
                MessageBox.Show("UserName Not Found");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            else
            {
                if(x.First().uName == textBox1.Text && x.First().uPass == textBox2.Text)
                {
                    MessageBox.Show("Login Successfully, Welcome " + textBox1.Text);
                    Appointment app = new Appointment();
                    app.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();


                }
            }
        }

        private void userTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.userTbl' table. You can move, or remove it, as needed.
            this.userTblTableAdapter.Fill(this.dataSet1.userTbl);

        }
    }
}
