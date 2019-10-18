using Microsoft.EntityFrameworkCore;
using Senai_autopecas_WebApi2.Domains;
using Senai_autopecas_WebApi2.Interfaces;
using Senai_autopecas_WebApi2.ViewmModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_autopecas_WebApi2.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuarios usuario)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Idusuario == usuario.Idusuario);
                usuarioBuscado.Email = usuario.Email;
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.First(x => x.Idusuario == id);

            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        //public void Deletar(int id)
        //{
        //    using (AutoPecasContext ctx = new AutoPecasContext())
        //    {
        //        Usuarios usuario = ctx.Usuarios.Find(id);
        //        ctx.Usuarios.Remove(usuario);
        //        ctx.SaveChanges();
        //    }
        //}

        public List<Usuarios> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
