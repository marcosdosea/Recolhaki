using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class EmpresaDTO
    {
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
    }
}
