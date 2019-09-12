using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentosRepository : ILancamentosRepository
    {
        public void Atualizar(Lancamentos lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            { 
                Lancamentos lancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.Idlancamentos == lancamentos.Idlancamentos);
                lancamentoBuscado.Titulo = lancamentos.Titulo;
                ctx.Lancamentos.Update(lancamentoBuscado);
                ctx.SaveChanges();


            }

        }

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.Idlancamentos == id);
            }
        }

        public void Cadastrar(Lancamentos lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamentos);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamentos = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(lancamentos);
                ctx.SaveChanges();
            }
        }

        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }
    }
}
