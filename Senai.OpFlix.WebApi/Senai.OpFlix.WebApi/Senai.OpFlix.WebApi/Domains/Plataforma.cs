using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataforma
    {
        public Plataforma()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Idplataforma { get; set; }
        public string Plataforma1 { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
