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

        // buscar por id
        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        // atualizar
        public void Atualizar(Estilos Estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == Estilos.IdEstilo);
                // update categorias set nome = @nome
                EstiloBuscado.Nome = Estilos.Nome;
                // insert - add, delete - remove, update - update
                ctx.Estilos.Update(EstiloBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        // deletar
        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // encontrar o item
                // chave primaria da tabela
                Estilos Estilo = ctx.Estilos.Find(id);
                // remover do contexto
                ctx.Estilos.Remove(Estilo);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }

    }
}
