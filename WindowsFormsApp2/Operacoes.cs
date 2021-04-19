using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApp2
{
    class Operacoes
    {
        private Conexao conexao = new Conexao();
        private MySqlCommand comando = new MySqlCommand();
        private string mensagem="";

        public string getMensagem { get => mensagem;}

        public Operacoes()
        {
        }
        public string pegaCodCategoria()
        {
            comando.CommandText = "select cat_cod from categoria";
            string categorias ="";
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    categorias += String.Format("{0} ",dr["cat_cod"]);
                }
                conexao.Desconectar();
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao buscar categorias";
            }
            return categorias;
        }
        public void addCategoria(string nome, string descricao)
        {
            comando.CommandText = "insert into categoria values " +
                "(default, @nome, @descricao)";
            comando.Parameters.AddWithValue("@nome",nome);
            comando.Parameters.AddWithValue("@descricao", descricao);
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Categoria cadastrada";
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao cadastrar categoria";
            }
            comando.Parameters.Clear();
        }
        public void adicionarProduto(string nomeProd, float precoProd, string marcaProd, string descricao, int categoria)
        {
            comando.CommandText = "insert into produto values " +
                "(default, @nome, @descricao,@marca, @preco, @categoria)";
            comando.Parameters.AddWithValue("@nome", nomeProd);
            comando.Parameters.AddWithValue("@descricao", descricao);
            comando.Parameters.AddWithValue("@marca", marcaProd);
            comando.Parameters.AddWithValue("@preco", precoProd);
            comando.Parameters.AddWithValue("@categoria", categoria);
            try {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Produto adicionado";
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao inserir produto na tabela";
            }
            comando.Parameters.Clear();
        }
        public void actualizarProduto(int id, string marcaProd, string nomeProd, float precoProd)
        {
            comando.CommandText = "update produto set prod_nome =@nome, prod_marca =@marca, prod_preco =@preco where prod_cod =@id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nomeProd);
            comando.Parameters.AddWithValue("@marca", marcaProd);
            comando.Parameters.AddWithValue("@preco", precoProd);
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Dados do produto actualizados";
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao actualizar dados do produto";

            }
            comando.Parameters.Clear();

        }
        public DataTable pegaProdutoId(int id)
        {
            comando.CommandText = "select  prod_cod as Codigo, prod_nome as Produto, prod_marca as Marca" +
                ", prod_descricao as Descricao, prod_preco as Preco from produto where prod_cod ="+id;
            //comando.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);
                conexao.Desconectar();
                mensagem = "Consulta feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Falha na consulta";
            }
            comando.Parameters.Clear();
            return dt;
        }
        public DataTable pegaTabelaProduto()
        {
            comando.CommandText = comando.CommandText = "select prod_cod as Codigo, prod_nome as Produto," +
                " prod_marca as Marca" +
                ", prod_descricao as Descricao, c.cat_nome as Categoria, prod_preco as Preco from produto join categoria c on produto.cod_cat=c.cat_cod;";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            try
            {
                comando.Connection = conexao.Conectar();
                da.Fill(dt);
                conexao.Desconectar();
            }
            catch (MySqlException)
            {

            }
            return dt;
        }
        public DataTable pegaTabelaCompra()
        {
            comando.CommandText = "select c.cliente_nome as `Nome do Cliente`," +
                " p.prod_nome `Produto`,  p.prod_descricao `Descricao do produto`, p.prod_preco `Preço`," +
                " cp.compra_quant `Quant`, cp.compra_valor_recebido `Valor Recebido`," +
                " cp.compra_data `Data da Compra` from compra cp " +
                " left join produto p on cp.cod_prod = p.prod_cod " +
                "left join cliente c on cp.cod_cliente = c.cliente_cod order by cp.compra_data asc;";
            DataTable dt = new DataTable();
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt); ///
                conexao.Desconectar();
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao ler tabela de compras";
            }
            return dt;
        }
        public DataTable pegaProdutoNome(string nome)
        {
            comando.CommandText = "select prod_cod as Codigo, prod_nome as Produto, prod_marca as Marca" +
                ", prod_descricao as Descricao, prod_preco as Preco from produto where prod_nome like '" + nome + "%'";
            DataTable dt = new DataTable();
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);
                conexao.Desconectar();
                mensagem = "Consulta feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Falha na consulta";
            }
            comando.Parameters.Clear();
            return dt;
        }
        public DataTable pegaProdutoMarca(string marca)
        {
            comando.CommandText = "select prod_cod as Codigo, prod_nome as Produto, prod_marca as Marca" +
                ", prod_descricao as Descricao, prod_preco as Preco from produto where prod_marca like '" + marca + "%'";
            DataTable dt = new DataTable();
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);
                conexao.Desconectar();
                mensagem = "Consulta feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Falha na consulta";
            }
            comando.Parameters.Clear();
            return dt;
        }
        public void apagarProduto(int id)
        {
            comando.CommandText = "delete from produto where prod_cod = "+id;
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Produto apagado";
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao apagar produto";
            }
            comando.Parameters.Clear();

        }
        public void adicionarCompraCompleta(int cod_prod, float quant, float vR, string[] nome, string bi, string tel)
        {
            //addCliente(nome, bi, tel);
            int cliente = 1;
            comando.CommandText = "insert into compra values" +
                "(default, @quantidade, default, @vRecebido)";
            comando.Parameters.AddWithValue("@quantidade",quant);
            comando.Parameters.AddWithValue("@vRecebido",vR);
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                comando.Dispose();
                conexao.Desconectar();
                mensagem = "Compra feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Erro na efectivacao da compra";
            }
            comando.Parameters.Clear();
            fazCompra(cod_prod, cliente);
        }
        private void fazCompra(int produto, int cliente)
        {
            comando.CommandText = "insert into faz_compra select Max(c.cliente_cod), @produto," +
                "Max(cp.compra_cod) from cliente as c, produto as p, compra as cp;";
            comando.Parameters.AddWithValue("@produto", produto);
            try
            { 
            
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao cadastrar o efeito da compra";
            }
        }
        
        public void adicionarCompra(int produto, int codCliente, int quant, float vR)
        {
            comando.CommandText = "insert into compra values (@produto, @cliente, @quantidade, default, @vRecebido);";
            comando.Parameters.AddWithValue("@produto", produto);
            comando.Parameters.AddWithValue("@cliente", codCliente);
            comando.Parameters.AddWithValue("@quantidade", quant);
            comando.Parameters.AddWithValue("@vRecebido", vR);
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Compra feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Erro na efectivacao da compra";
            }
            comando.Parameters.Clear();
        }
        public int getCodCliente(string doc, string nr)
        {
            int cod = 0;
            comando.CommandText = "select cliente_cod from cliente" +
                " where (cliente_nr_documento like @nr) and (cliente_documento = @doc)";
            comando.Parameters.AddWithValue("@nr", nr);
            comando.Parameters.AddWithValue("@doc", doc);
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataReader dr = comando.ExecuteReader();
                dr.Read();
                cod = int.Parse(dr.GetString("cliente_cod"));
                conexao.Desconectar();

            }
            catch (MySqlException)
            {
                mensagem = "Erro ao procurar cliente";
            }
            comando.Parameters.Clear();
            return cod;
        }
        public string docCliente(string doc, string nr)
        {
            string docNr = "";
            comando.CommandText = "select cliente_nr_documento from cliente" +
                " where (cliente_nr_documento like @nr) and (cliente_documento = @doc)";
            comando.Parameters.AddWithValue("@nr", nr);
            comando.Parameters.AddWithValue("@doc", doc);
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataReader dr = comando.ExecuteReader();
                dr.Read();
                docNr = dr.GetString("cliente_nr_documento");
                conexao.Desconectar();
                
            }
            catch (MySqlException)
            {
                mensagem = "Erro ao procurar cliente";
            }
            comando.Parameters.Clear();
            return docNr;
        }
        public DataTable clientes()
        {
            comando.CommandText = "select * from cliente";
            DataTable dt = new DataTable();
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);
                conexao.Desconectar();
                mensagem = "Consulta feita com sucesso";
            }
            catch (MySqlException)
            {
                mensagem = "Falha na consulta";
            }
            comando.Parameters.Clear();
            return dt;
        }
        public void addCliente(string []n, string documento, string nrDoc,
            string localidade, string bairro, string quarteirao, string numCasa,
            string tel1, string tel2, string email)
        {
           // comando.CommandText = "insert into cliente values (default, 'Mapie', 'Mamunhe', 'BI', '10005A', 'Matola', 'Machava', '12', '447', '84555252', '85889988', 'mmmma');";
            comando.CommandText = "insert into cliente values (default, @pNome, @uNome, @doc, @nrDoc, @localidade, @bairro, @quart, @nrcasa, @tel1, @tel2, @email);";
            //comando.CommandText = "insert into cliente values (default, @nome, @apelido, @documento, @nr, @local, @bairro, @quarteirao, @casa)";
            comando.Parameters.AddWithValue("@pNome", n[0]);
            comando.Parameters.AddWithValue("@uNome", n[n.Length-1]);
            comando.Parameters.AddWithValue("@doc", documento);
            comando.Parameters.AddWithValue("@nrDoc", nrDoc);
            comando.Parameters.AddWithValue("@localidade", localidade);
            comando.Parameters.AddWithValue("@bairro", bairro);
            comando.Parameters.AddWithValue("@quart", quarteirao);
            comando.Parameters.AddWithValue("@nrcasa", numCasa);
            comando.Parameters.AddWithValue("@tel1", tel1);
            comando.Parameters.AddWithValue("@tel2", tel2);
            comando.Parameters.AddWithValue("@email", email);
            try
            {
                comando.Connection = conexao.Conectar();
                comando.ExecuteNonQuery();
                conexao.Desconectar();
                mensagem = "Cliente Cadastrado";

            }
            catch (MySqlException)
            {
                mensagem = "Erro ao cadastrar Cliente";
            }
            comando.Parameters.Clear();
        }


    }
}
