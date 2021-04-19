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
    public partial class F_addCliente : Form
    {
        private Operacoes operacao = new Operacoes();
        private Validar validar = new Validar();
        public F_addCliente()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] nome = {txtPNome.Text, txtUNome.Text};
            string doc = cbDoc.Text, nrDoc = txtDocNum.Text,
                localidade = txtLocalidade.Text, bairro = txtBairro.Text,
                quart = txtQuart.Text, numCasa = upCasa.Value.ToString(),
                tel1 = txtTel1.Text, tel2 = txtTel2.Text, email=txtEmail.Text;
            try
            {
                validar.Campo(txtPNome.Text);
                validar.Campo(cbDoc.Text);
                validar.Campo(txtDocNum.Text);
                validar.telefone(txtTel1.Text);
                operacao.addCliente(nome,doc,nrDoc,localidade,bairro,quart,numCasa,
                    tel1,tel2,email);
                MessageBox.Show(operacao.getMensagem, "Relatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Preencha os campos", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Preencha os campos", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            /*catch (FormatException)
            {
                MessageBox.Show("Insira apenas números de telefone válidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
