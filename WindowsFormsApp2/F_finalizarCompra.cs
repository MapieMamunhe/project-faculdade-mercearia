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
    public partial class F_finalizarCompra : Form
    {
        private Operacoes operacao = new Operacoes();
        private int quant, prod_cod;
        public F_finalizarCompra(int prod_cod, float vPagar, int quant)
        {
            InitializeComponent();
            lblVPagar.Text = vPagar.ToString();
            this.quant = quant;
            this.prod_cod = prod_cod;

        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float trocos = float.Parse(lblVPagar.Text) - (float)upVrecebido.Value;
            if (trocos >= 0)
            {
                lblTrocos.Text = "0";
            }
            else
            {
                lblTrocos.Text = ((-1)*trocos).ToString();
            } 
        }
        private Validar validar = new Validar();
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                pesquisarProduto("pesquisar");
            }
            catch (FormatException)
            {
                MessageBox.Show("Cliente Nao encontrado", "Resposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void pesquisarProduto(string origem)
        {
            try
            {
                validar.Campo(txtDocNum.Text);
                validar.Campo(cbDoc.Text);
                string nr = operacao.docCliente(cbDoc.Text, txtDocNum.Text);
                if (nr == txtDocNum.Text)
                {
                    if (origem.Equals("pesquisar"))
                    {
                        MessageBox.Show("Cliente Encontrado", "Resposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (ArgumentException)
            {
            }
            }

            private void LblTrocos_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            float vR = (float) upVrecebido.Value;
            float vP = float.Parse(lblVPagar.Text);
            if ((vR>=vP))
            {
                try
                {
                    if (vP == 0)
                    {
                        throw new ArithmeticException();
                    }
                    int codCliente = 1;
                    if (!string.IsNullOrEmpty(txtDocNum.Text))
                    {
                        pesquisarProduto("");
                        codCliente = operacao.getCodCliente(cbDoc.Text, txtDocNum.Text);
                    }
                    operacao.adicionarCompra(prod_cod, codCliente, quant, (float)upVrecebido.Value);
                    MessageBox.Show(operacao.getMensagem, "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblVPagar.Text = "0";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Cliente Nao encontrado", "Resposta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArithmeticException)
                {
                    MessageBox.Show("O Pegamento ja foi efectuado", "Nada a pagar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro ao finalizar a compra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("O valor que inseriu e inferior ao valor total a pagar", "Insuficiencia de Fundos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void F_finalizarCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
