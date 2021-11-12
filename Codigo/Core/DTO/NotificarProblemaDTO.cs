using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class NotificarProblemaDTO
    {
        public string Nome { get; set; }
        public string NomeMaterialReciclavel { get; set; }
        public DateTime DataManifestacaoInteresse { get; set; }
        public string Descricao { get; set; }
    }
}
