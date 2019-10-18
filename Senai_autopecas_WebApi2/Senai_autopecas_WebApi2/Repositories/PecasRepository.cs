using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai_autopecas_WebApi2.Domains;

namespace Senai_autopecas_WebApi2.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecaBuscada = ctx.Pecas.FirstOrDefault(x => x.Idpeca == pecas.Idpeca);
                pecaBuscada.Codigopeca = pecas.Codigopeca;
                ctx.Pecas.Update(pecaBuscada);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.Idpeca == id);
            }
        }

        public void Cadastrar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(pecas);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecas = ctx.Pecas.Find(id);
                ctx.Pecas.Remove(pecas);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
