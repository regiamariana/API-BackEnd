using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int Idlancamentos { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int? Idcategoria { get; set; }
        public int? Idtipo { get; set; }
        public TimeSpan Tempoduracao { get; set; }
        public DateTime Datalancamento { get; set; }
        public int? Idplataforma { get; set; }
        public int? Idclassificacao { get; set; }
        public int? Idclassificaca { get; set; }

        public Categoria IdcategoriaNavigation { get; set; }
        public Classificacao IdclassificacaoNavigation { get; set; }
        public Plataforma IdplataformaNavigation { get; set; }
        public Tipo IdtipoNavigation { get; set; }
    }
}
