using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Tipousuario
    {
        public Tipousuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idtipousuario { get; set; }
        public string Tipousuario1 { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
