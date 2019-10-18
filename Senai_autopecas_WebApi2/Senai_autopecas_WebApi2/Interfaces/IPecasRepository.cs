using Senai_autopecas_WebApi2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_autopecas_WebApi2
{
    interface IPecasRepository
    {
        List<Pecas> Listar();

        void Cadastrar(Pecas pecas);

        Pecas BuscarPorId(int id);

        void Atualizar(Pecas pecas);

        void Deletar(int id);

    }
}
