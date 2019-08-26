using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                // facilitar a nossa vida
                // select * from categorias;
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos Estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // insert into categorias (nome) values (@nome);
                ctx.Estilos.Add(Estilos);
                ctx.SaveChanges();
            }
        }
    }
}
