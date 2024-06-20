using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectPBO.view
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == "admin" && textPassword.Text == "12345")
            {
                //melanjutkan ke form selanjutnya
                DataBook dataBuku = new DataBook();
                dataBuku.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username / Password Salah");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
