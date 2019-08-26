using Senai.Gufos.WepApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WepApi.Repository
{
    public class CategoriaRepository
    {
        public List<Categorias>Listar() {
            using (GufosContext ctx = new GufosContext())
            {
                //facilitar vida
                //select
                return ctx.Categorias.ToList();
            }


        }

        public void Cadastrar(Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                //insert into categorias (nome) values (@nome)
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }

        //buscar por id
        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategorias == id);
            }
        }

        //atualiza
        public void Atualizar(Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategorias == categorias.IdCategorias);
                //update categoria set etc bla
                CategoriaBuscada.Nome = categorias.Nome;
                //ensert - add, delete
                ctx.Categorias.Update(CategoriaBuscada);
                //efetivar
                ctx.SaveChanges();
            }
        }

        //deletar
        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoria = ctx.Categorias.Find(id);
                ctx.Categorias.Remove(categoria);
                ctx.SaveChanges();
            }
        }
    }
}
