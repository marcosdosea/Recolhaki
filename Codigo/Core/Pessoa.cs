using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Avaliacao = new HashSet<Avaliacao>();
            Empresacoletor = new HashSet<Empresacoletor>();
            MaterialreciclavelIdPessoaColetorNavigation = new HashSet<Materialreciclavel>();
            MaterialreciclavelIdPessoaDoadorNavigation = new HashSet<Materialreciclavel>();
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

        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<Empresacoletor> Empresacoletor { get; set; }
        public virtual ICollection<Materialreciclavel> MaterialreciclavelIdPessoaColetorNavigation { get; set; }
        public virtual ICollection<Materialreciclavel> MaterialreciclavelIdPessoaDoadorNavigation { get; set; }
    }
}
