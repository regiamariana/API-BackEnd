using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int Idpeca { get; set; }
        public string Codigopeca { get; set; }
        public string Descricao { get; set; }
        public int? Peso { get; set; }
        public int? Precocusto { get; set; }
        public int? Precovenda { get; set; }
        public int? Idfornecedor { get; set; }

        public Fornecedores IdfornecedorNavigation { get; set; }
    }
}
