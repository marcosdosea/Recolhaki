using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.ViewModels
{
    public class AutorizarColetorViewModel
    {
        public int ColetorIdColetor { get; set; }
        public DateTime DataAutorizacao { get; set; }
        public string StatusAutorizacao { get; set; }
    }
}
