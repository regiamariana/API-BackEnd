using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentosRepository
    {
        List<Lancamentos> Listar();

        void Cadastrar(Lancamentos lancamentos);

        Lancamentos BuscarPorId(int id);

        void Atualizar(Lancamentos lancamentos);

        void Deletar(int id);
    }
}
