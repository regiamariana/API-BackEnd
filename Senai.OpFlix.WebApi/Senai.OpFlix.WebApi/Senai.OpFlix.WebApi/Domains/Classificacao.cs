using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Classificacao
    {
        public Classificacao()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int Idclassificacao { get; set; }
        public string Classificacao1 { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
