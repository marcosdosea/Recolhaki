using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AvaliacaoDTO
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
