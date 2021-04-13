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
    public partial class F_compra : Form
    {
        private Validar validar = new Validar();
        private Operacoes operacao = new Operacoes();
        private int cod_prod;
        private float preco;
        public F_compra()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private DataTable tabelaFinal(string termo)
        {
            
            if (termo.Equals("Id"))
            {
                return operacao.pegaProdutoId(int.Parse(txtProduto.Text));
            }
            else
            {
                if (termo.Equals("Marca"))
                {
                    return operacao.pegaProdutoMarca(txtProduto.Text);
                }
                else
                {
                    return operacao.pegaProdutoNome(txtProduto.Text);
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                validar.Campo(txtProduto.Text);
                string termo = cbTermo.Text;
                dtvProd.DataSource = tabelaFinal(termo);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Preencha o campo", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira um número Inteiro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtvProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cod_prod = (int) dtvProd.Rows[e.RowIndex].Cells["Codigo"].Value;
            preco = (float)dtvProd.Rows[e.RowIndex].Cells["Preco"].Value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            float valorPagar = 0;
            try
            {
                validar.celulaSelecionada((int)upQuantidade.Value);
                validar.celulaSelecionada(cod_prod);
                valorPagar = (float)upQuantidade.Value * preco;
                if (!(string.IsNullOrEmpty(txtCPrimeiroNome.Text) || (string.IsNullOrWhiteSpace(txtCPrimeiroNome.Text))))
                {
                    validar.Campo(txtBI.Text);
                    validar.telefone(txtTel.Text);
                    F_finalizarCompra fc = new F_finalizarCompra(cod_prod, valorPagar,(int) upQuantidade.Value, 
                        txtCPrimeiroNome.Text+" "+txtCUltimoNome.Text, txtBI.Text, txtTel.Text);
                    fc.ShowDialog();
                }
                else
                {
                    F_finalizarCompra fc = new F_finalizarCompra(cod_prod, valorPagar, (int)upQuantidade.Value);
                    fc.ShowDialog();
                }


            }
            catch (ArgumentException)
            {
                MessageBox.Show("Informe a quantidade e selecione o produto a ser comprado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira apenas números de telefone válidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComprasEfectuadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_tabelaCompras tc = new F_tabelaCompras();
            tc.FormClosed += (s, args) => this.Show();
            tc.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtCPrimeiroNome.Text = "";
            txtCUltimoNome.Text = "";
            txtBI.Text = "";
            txtTel.Text = "";
        }
    }
}
