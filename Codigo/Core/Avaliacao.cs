using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int NumeroEstrelas { get; set; }
        public int IdPessoa { get; set; }
        public int IdMaterialReciclavel { get; set; }
        public string Tipo { get; set; }

        public virtual Materialreciclavel IdMaterialReciclavelNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
