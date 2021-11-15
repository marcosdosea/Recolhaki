using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AutorizarColetorDTO
    {
        public int ColetorIdColetor { get; set; }
        public DateTime DataAutorizacao { get; set; }
        public string StatusAutorizacao { get; set; }
    }
}
