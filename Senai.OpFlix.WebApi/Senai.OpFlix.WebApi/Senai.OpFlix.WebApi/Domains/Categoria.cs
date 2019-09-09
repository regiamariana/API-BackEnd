using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Idcategoria { get; set; }
        public string Categoria1 { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
