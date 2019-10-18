using System;
using System.Collections.Generic;

namespace Senai_autopecas_WebApi2.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Fornecedores = new HashSet<Fornecedores>();
        }

        public int Idusuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }

        public ICollection<Fornecedores> Fornecedores { get; set; }
    }
}
