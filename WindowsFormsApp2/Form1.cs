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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            F_Actualizar fa = new F_Actualizar();
            fa.FormClosed += (s, args)=> this.Show();
            fa.Show();
            this.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            F_compra fc = new F_compra();
            fc.FormClosed += (s, args) => this.Show();
            fc.Show();
            this.Hide();
        }
        private Operacoes operacao = new Operacoes();

        private void Button3_Click(object sender, EventArgs e)
        {
            F_Produtos fp = new F_Produtos(operacao.pegaTabelaProduto(), "Produtos");
            fp.FormClosed += (s, args) => this.Show();
            fp.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
