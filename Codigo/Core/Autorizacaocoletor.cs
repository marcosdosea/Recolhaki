using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Autorizacaocoletor
    {
        public int ColetorIdColetor { get; set; }
        public int PessoaIdPessoa { get; set; }
        public DateTime DataAutorizacao { get; set; }
        public string StatusAutorizacao { get; set; }

        public virtual Coletor ColetorIdColetorNavigation { get; set; }
        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
    }
}
