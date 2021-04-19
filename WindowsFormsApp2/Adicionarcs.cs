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
    public partial class F_Adicionar : Form
    {
        public Validar validar = new Validar();
        private Operacoes operacao = new Operacoes();
        public F_Adicionar()
        {
            InitializeComponent();
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Eliminar fe = new F_Eliminar();
            fe.FormClosed += (s, args) => this.Close();
            fe.Show();
            this.Hide();
        }

        private void ActualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Actualizar fa = new F_Actualizar();
            fa.FormClosed += (s, args) => this.Close();
            fa.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try {
                /*Validar os campos*/
                validar.Campo(txtProdNome.Text);
                validar.Campo(txtProdMarca.Text);
                validar.Campo(rxtDescricao.Text);
                validar.Campo(cbCategoria.Text);
                validar.celulaSelecionada((int) upPreco.Value);
                //Adiciona o Produto
                operacao.adicionarProduto(txtProdNome.Text, (float) upPreco.Value, txtProdMarca.Text, rxtDescricao.Text, int.Parse(cbCategoria.Text));
                //Mensagem de confirmacao
                MessageBox.Show(operacao.getMensagem, "Resposta da inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Por favor preencha todos campos com valores válidos", "Campos Vazios ou inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void F_Adicionar_Load(object sender, EventArgs e)
        {
            string []categorias = operacao.pegaCodCategoria().Split();
            cbCategoria.Items.AddRange(categorias);
        }

        private void Btn_addCategora_Click(object sender, EventArgs e)
        {
            F_addCategoria c = new F_addCategoria();
            c.FormClosed += (s, args) => this.Show();
            this.Hide();
            c.ShowDialog();
            
        }
    }
}
