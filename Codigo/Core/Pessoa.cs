using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Autorizacaocoletor = new HashSet<Autorizacaocoletor>();
            Avaliacao = new HashSet<Avaliacao>();
            Doacaomaterialreciclavel = new HashSet<Doacaomaterialreciclavel>();
            Notificacao = new HashSet<Notificacao>();
        }

        public int IdPessoa { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Autorizacaocoletor> Autorizacaocoletor { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<Doacaomaterialreciclavel> Doacaomaterialreciclavel { get; set; }
        public virtual ICollection<Notificacao> Notificacao { get; set; }
    }
}
