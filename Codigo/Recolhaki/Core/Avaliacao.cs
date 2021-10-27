using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public string Descricao { get; set; }
        public int IdEmoje { get; set; }
        public int PessoaIdPessoa { get; set; }
        public int DoacaoMaterialReciclavelIdDoacaoMaterialReciclavel { get; set; }

        public virtual Doacaomaterialreciclavel DoacaoMaterialReciclavelIdDoacaoMaterialReciclavelNavigation { get; set; }
        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
    }
}
