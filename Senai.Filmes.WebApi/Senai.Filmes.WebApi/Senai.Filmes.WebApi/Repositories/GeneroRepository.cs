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
        //ATENÇÃO SUA TOLIIIINHA, ESSE MÉTODO VAI USAR OS ATRIBUTOS DO DOMAIN,
        //POR ISSO ESTÁ ESCRITO DO LADO DO PUBLIC
        //estamos fazendo conex com o banco, preste atençao grr
        public GeneroDomains BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        while (sdr.Read())
                        {
                            GeneroDomains genero = new GeneroDomains
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;

                    // retornar
                }


            }
        }

        public void Cadastrar(GeneroDomains generoDomains)
        {
            string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomains.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(GeneroDomains generoDomains)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @Id";
            // estabelecer a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomains.Nome);
                cmd.Parameters.AddWithValue("@Id", generoDomains.IdGenero);
                // abre a conexao
                con.Open();
                cmd.ExecuteNonQuery();
            }

            // executa
        }
    }
}