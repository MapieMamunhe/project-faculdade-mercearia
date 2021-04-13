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
    public partial class F_Actualizar : Form
    {
        public Validar validar = new Validar();
        private Operacoes operacao = new Operacoes();
        private string prod;
        public F_Actualizar()
        {
            InitializeComponent();
        }

        private void AdicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Adicionar fAdicionar = new F_Adicionar();
            fAdicionar.FormClosed += (s, args) => this.Close();
            fAdicionar.Show();
            this.Hide();
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Eliminar fe = new F_Eliminar();
            fe.FormClosed += (s, args) => this.Close();
            fe.Show();
            this.Hide();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dtvProduto.DataSource = (operacao.pegaProdutoId((int)upID.Value));
                string prod = (string)dtvProduto.Rows[0].Cells["Produto"].Value;
                string marca = (string)dtvProduto.Rows[0].Cells["Marca"].Value;
                txtNome.Text = prod;
                txtMarca.Text = marca;
                MessageBox.Show(operacao.getMensagem);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nenhum Produto encontrado", "Informação");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                validar.Campo(txtNome.Text);
                validar.Campo(txtMarca.Text);
                validar.celulaSelecionada((int) upPreco.Value);
                int c = (int) MessageBox.Show("Tem a certeza que deseja modificar essas informações?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (c == 6)
                {
                    operacao.actualizarProduto((int)upID.Value, txtMarca.Text, txtNome.Text, (float)upPreco.Value);
                    MessageBox.Show(operacao.getMensagem, "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Actualizar lista de produtos
                    dtvProduto.DataSource = (operacao.pegaProdutoNome(prod));
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Preencha os campos com valores válidos", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DtvProduto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DtvProduto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            prod = dtvProduto.Rows[e.RowIndex].Cells["Produto"].Value.ToString();
        }
    }
}
