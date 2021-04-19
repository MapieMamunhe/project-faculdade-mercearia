using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text, pwd = txtPwd.Text;
            try
            {
                dados(user,pwd);
                Form1 f = new Form1();
                f.FormClosed += (s, args) => this.Close();
                this.Hide();
                f.ShowDialog();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Dados Invalidos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void dados(string u, string p)
        {
            Login l = new Login();
            string []pega = l.userPass(u, p);
            string inUser = pega[0], inPass=pega[1];

            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                throw new ArgumentException();
            }
            else
            {
                if (!(u.Equals(inUser) && p.Equals(inPass)))
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
