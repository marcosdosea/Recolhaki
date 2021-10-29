using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Notificacao
    {
        public Notificacao()
        {
            Doacaomaterialreciclavel = new HashSet<Doacaomaterialreciclavel>();
        }

        public int IdNotificacao { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
        public int PessoaIdPessoa { get; set; }

        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
        public virtual ICollection<Doacaomaterialreciclavel> Doacaomaterialreciclavel { get; set; }
    }
}
