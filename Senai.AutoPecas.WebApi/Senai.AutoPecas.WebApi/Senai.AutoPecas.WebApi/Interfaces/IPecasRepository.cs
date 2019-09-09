using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecasRepository
    {
        List<Pecas> Listar();

        void Cadastrar(Pecas pecas);

        Pecas BuscarPorId(int id);

        void Atualizar(Pecas pecas);

        void Deletar(int id);
    }
}
