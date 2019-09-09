﻿using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
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

        public ICollection<Fornecedores> Fornecedores { get; set; }
    }
}
