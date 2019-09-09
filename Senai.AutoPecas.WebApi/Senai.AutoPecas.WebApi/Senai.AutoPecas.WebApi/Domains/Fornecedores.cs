using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public Fornecedores()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int Idfornecedor { get; set; }
        public int Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public string Endereco { get; set; }
        public int? Idusuario { get; set; }

        public Usuarios IdusuarioNavigation { get; set; }
        public ICollection<Pecas> Pecas { get; set; }
    }
}
