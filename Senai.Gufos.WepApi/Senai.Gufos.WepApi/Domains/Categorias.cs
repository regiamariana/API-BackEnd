using System;
using System.Collections.Generic;

namespace Senai.Gufos.WepApi.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int IdCategorias { get; set; }
        public string Nome { get; set; }

        public ICollection<Eventos> Eventos { get; set; }
    }
}
