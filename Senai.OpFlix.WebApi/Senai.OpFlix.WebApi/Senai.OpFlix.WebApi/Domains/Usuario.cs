using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Telefone { get; set; }
        public int? Idtipousuario { get; set; }
        public byte[] Imagem { get; set; }

        public Tipousuario IdtipousuarioNavigation { get; set; }
    }
}
