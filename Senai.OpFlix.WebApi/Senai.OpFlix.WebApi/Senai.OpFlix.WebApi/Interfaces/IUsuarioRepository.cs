using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario BuscarPorEmailESenha(LoginViewModel login);

        List<Usuario> Listar();

        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(int id);

        void Atualizar(Usuario usuario);

        void Deletar(int id);
    }
}
