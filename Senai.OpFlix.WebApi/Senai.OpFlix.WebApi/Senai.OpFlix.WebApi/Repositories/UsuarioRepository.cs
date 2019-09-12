using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuario usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuario UsuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Idusuario == usuario.Idusuario);
                UsuarioBuscado.Nome = usuario.Nome;
                ctx.Usuario.Update(UsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuario usuario = ctx.Usuario.Include(x => x.IdtipousuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.FirstOrDefault(x => x.Idusuario == id);
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuario usuario = ctx.Usuario.Find(id);
                ctx.Usuario.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuario.ToList();
            }
        }
    }
}
