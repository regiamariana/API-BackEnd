using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Atualizar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataforma plataformaBuscada = ctx.Plataforma.FirstOrDefault(x => x.Idplataforma == plataforma.Idplataforma);
                plataformaBuscada.Plataforma1 = plataforma.Plataforma1;
                ctx.Plataforma.Update(plataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public Plataforma BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.Idplataforma == id); 
            }
        }

        public void Cadastrar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataforma.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            { 
                Plataforma plataforma = ctx.Plataforma.Find(id);
                // remover do contexto
                ctx.Plataforma.Remove(plataforma);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }

        public List<Plataforma> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.ToList();
            }
        }
    }
}
