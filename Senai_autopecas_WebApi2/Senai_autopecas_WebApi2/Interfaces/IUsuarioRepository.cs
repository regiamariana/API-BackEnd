using Senai_autopecas_WebApi2.Domains;
using Senai_autopecas_WebApi2.ViewmModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_autopecas_WebApi2.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        List<Usuarios> Listar();

        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(int id);

        void Atualizar(Usuarios usuario);

        //void Deletar(int id);
    }
}
