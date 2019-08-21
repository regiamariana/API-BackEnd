using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Mariana.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionarios { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }
        public DateTime datanascimento { get; set; }
}
}
