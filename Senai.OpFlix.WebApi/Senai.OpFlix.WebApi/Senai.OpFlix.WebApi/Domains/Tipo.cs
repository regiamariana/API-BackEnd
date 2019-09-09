using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Tipo
    {
        public Tipo()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Idtipo { get; set; }
        public string Tipo1 { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
