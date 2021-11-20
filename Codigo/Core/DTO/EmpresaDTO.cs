using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class EmpresaDTO
    {
        public string Cpf_Cnpj { get; set; }
        public string Instituicao { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }
        public string Responsavel { get; set; }
        public string Senha { get; set; }

        public int Cep { get; set; }
        public string Lougadoro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
    }
}
