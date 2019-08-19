using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositorios
{
    public class EstiloRepository
    {
        private string StringConexao = "Data sOURCES = .\\SqlExpress;Initial " +
            "Catalog = T_SStop;User Id=sa; Pwd=132;";
        public List<EstiloDomain> Listar() {
            //buscar dados no bancoh deh dados
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //chamar o banco - string de conexao 
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicais";
                //abrir a conexao
                con.Open();

                //percorrer a lista
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read)
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        }
                    }
                }
            }
            return estilo;
        }
    }
}
