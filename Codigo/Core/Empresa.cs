using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Empresa
    {
        public Empresa()
        {
            Empresacoletor = new HashSet<Empresacoletor>();
            Materialreciclavel = new HashSet<Materialreciclavel>();
        }

        public int IdEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Empresacoletor> Empresacoletor { get; set; }
        public virtual ICollection<Materialreciclavel> Materialreciclavel { get; set; }
    }
}
