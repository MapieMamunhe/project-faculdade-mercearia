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
    public partial class F_addCategoria : Form
    {
        private Operacoes operacao = new Operacoes();
        private Validar validar = new Validar();
        public F_addCategoria()
        {
            InitializeComponent();
        }

        private void Btn_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                validar.Campo(txtCatNome.Text);
                validar.Campo(rxtDescricao.Text);
                operacao.addCategoria(txtCatNome.Text, rxtDescricao.Text);
                MessageBox.Show(operacao.getMensagem, "Relatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCatNome.Text = "";
                rxtDescricao.Text = "";
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Os campos nome e descricao nao podem estar vazios", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
