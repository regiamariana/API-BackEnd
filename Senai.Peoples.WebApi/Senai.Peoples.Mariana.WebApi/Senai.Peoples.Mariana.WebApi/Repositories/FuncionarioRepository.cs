using Senai.Peoples.Mariana.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Mariana.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        // aonde que será feita essa comunicação
        // private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";
        private string StringConexao = "Data Source =.\\SqlExpress;Initial Catalog =T_Peoples;User Id=sa; Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            //usa atributos do domain do funcionário 

            // chamar o banco - declaro passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // nossa query a ser executada
                string Query = "SELECT IDFUNCIONARIOS, NOME, datanascimento FROM FUNCIONARIOS";
                // ABRIR CONEXAAAAAAAAAO
                con.Open();

                // DECLARO para percorrer a lista
                SqlDataReader sdr;
                // comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os valores da tabela do banco e armazenar dentro da aplicacao do backend
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionarios = Convert.ToInt32(sdr["IDFUNCIONARIOS"]),
                            Nome = sdr["NOME"].ToString(),
                           // datanascimento = Convert.ToDateTime(sdr["datanascimento"])
                           //RESOLVER DEPOIS 
                        };
                        funcionarios.Add(funcionario);
                    }
                }

            }
            // executar o select
            // retornar as informacoes

            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT IDFUNCIONARIOS, Nome, datanascimento FROM FUNCIONARIOS WHERE IDFUNCIONARIOS = @IDFUNCIONARIOS";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IDFUNCIONARIOS", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionarios = Convert.ToInt32(sdr["IDFUNCIONARIOS"]),
                                Nome = sdr["Nome"].ToString(),
                                datanascimento = Convert.ToDateTime(sdr["datanascimento"])
                            };
                            return funcionario;
                        }
                    }
                    return null;

                    // retornar
                }
            }
        }

        public void Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT FUNCIONARIOS (NOME) VALUES (@NOME);";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM FUNCIONARIOS WHERE IDFUNCIONARIOS = @Id";
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

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE FUNCIONARIOS SET Nome = @Nome WHERE IDFUNCIONARIOS = @Id";
            // estabelecer a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionarios);
                // abre a conexao
                con.Open();
                cmd.ExecuteNonQuery();
            }

            // executa
        }

        public void CadastrarData(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE FUNCIONARIOS SET datanascimento = @data WHERE IDFUNCIONARIOS = @id;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@data", funcionarioDomain.datanascimento);
                cmd.Parameters.AddWithValue("@id", funcionarioDomain.IdFuncionarios);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
