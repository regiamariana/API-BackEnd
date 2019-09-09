using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Atualizar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categoria CategoriasBuscadas = ctx.Categoria.FirstOrDefault(x => x.Idcategoria == categoria.Idcategoria);
                // update categorias set nome = @nome
                CategoriasBuscadas.Categoria1 = categoria.Categoria1;
                // insert - add, delete - remove, update - update
                ctx.Categoria.Update(CategoriasBuscadas);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public Categoria BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.Find(id);
            }
        }

        public void Cadastrar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.ToList();
            }
        }
    }
}
