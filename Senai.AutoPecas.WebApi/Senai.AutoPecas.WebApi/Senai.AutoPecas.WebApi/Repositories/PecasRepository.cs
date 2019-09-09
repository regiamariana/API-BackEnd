using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecasBuscadas = ctx.Pecas.FirstOrDefault(x => x.Idpeca == pecas.Idpeca);
                // update categorias set nome = @nome
                PecasBuscadas.Descricao = pecas.Descricao;
                // insert - add, delete - remove, update - update
                ctx.Pecas.Update(PecasBuscadas);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Find(id);
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
                // encontrar o item
                // chave primaria da tabela
                Pecas Peca = ctx.Pecas.Find(id);
                // remover do contexto
                ctx.Pecas.Remove(Peca);
                // efetivar as mudanças no banco de dados
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
