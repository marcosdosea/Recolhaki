using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Coletor
    {
        public Coletor()
        {
            Autorizacaocoletor = new HashSet<Autorizacaocoletor>();
            Doacaomaterialreciclavel = new HashSet<Doacaomaterialreciclavel>();
        }

        public int IdColetor { get; set; }
        public string Coletorcol { get; set; }

        public virtual ICollection<Autorizacaocoletor> Autorizacaocoletor { get; set; }
        public virtual ICollection<Doacaomaterialreciclavel> Doacaomaterialreciclavel { get; set; }
    }
}
