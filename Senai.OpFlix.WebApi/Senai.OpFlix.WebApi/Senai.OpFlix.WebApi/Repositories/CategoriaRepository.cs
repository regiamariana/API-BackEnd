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
                return ctx.Categoria.FirstOrDefault(x => x.Idcategoria == id);
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
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // encontrar o item
                // chave primaria da tabela
                Categoria Categoria = ctx.Categoria.Find(id);
                // remover do contexto
                ctx.Categoria.Remove(Categoria);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
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
