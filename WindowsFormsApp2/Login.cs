using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public class Login
    {
        MySqlCommand comando = new MySqlCommand();
        Conexao conexao = new Conexao();
        public Login()
        {

        }
        public string[] userPass(string u, string p)
        {
            string []resposta = new string[2];
            comando.CommandText = "select nome, senha from users where (nome=@u) and (senha=@p);";
            comando.Parameters.AddWithValue("@u",u);
            comando.Parameters.AddWithValue("@p", p);
            try
            {
                comando.Connection = conexao.Conectar();
                MySqlDataReader dr = comando.ExecuteReader();
                dr.Read();
                resposta[0] = dr.GetString("nome");
                resposta[1] = dr.GetString("senha");
                conexao.Desconectar();

            }
            catch (MySqlException)
            {

            }
            comando.Parameters.Clear();
            return resposta;
        }
    }
}
