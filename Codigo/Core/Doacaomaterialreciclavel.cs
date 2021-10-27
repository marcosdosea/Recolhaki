using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Doacaomaterialreciclavel
    {
        public Doacaomaterialreciclavel()
        {
            Avaliacao = new HashSet<Avaliacao>();
        }

        public int IdDoacaoMaterialReciclavel { get; set; }
        public int Tipo { get; set; }
        public string Nome { get; set; }
        public float Peso { get; set; }
        public DateTime DataManifestacaoInteresse { get; set; }
        public int PessoaIdPessoa { get; set; }
        public int NotificacaoIdNotificacao { get; set; }
        public int ColetorIdColetor { get; set; }

        public virtual Coletor ColetorIdColetorNavigation { get; set; }
        public virtual Notificacao NotificacaoIdNotificacaoNavigation { get; set; }
        public virtual Pessoa PessoaIdPessoaNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
