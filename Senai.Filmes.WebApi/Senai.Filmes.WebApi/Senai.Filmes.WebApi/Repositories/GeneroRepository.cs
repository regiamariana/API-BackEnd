using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        // aonde que será feita essa comunicação
        // private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<GeneroDomains> Listar()
        {
            List<GeneroDomains> genero = new List<GeneroDomains>();

            // chamar o banco - declaro passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // nossa query a ser executada
                string Query = "SELECT IdGenero, Nome FROM Generos";
                // abrir a conexao
                con.Open();

                // declaro para percorrer a lista
                SqlDataReader sdr;
                // comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os valores da tabela do banco e armazenar dentro da aplicacao do backend
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomains generos = new GeneroDomains
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        genero.Add(generos);
                    }
                }

            }
            // executar o select
            // retornar as informacoes

            return genero;

        }
    }
}