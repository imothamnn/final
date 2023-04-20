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
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(passtxt.Text == "")
            {
                MessageBox.Show("Enter The admin Password");

            }
            else if(passtxt.Text == "Password")
            {
                User u = new User();
                u.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact The Admin");
            }
        }
    }
}
