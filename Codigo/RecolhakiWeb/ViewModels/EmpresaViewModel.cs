using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.ViewModels
{
    public class EmpresaViewModel
    {
        [Required]
        [Key]
        public int IdPessoa { get; set; }
        [StringLength(30)]
        public string Cpf_Cnpj { get; set; }
        public string Instituicao { get; set; }
        public string Email { get; set; }

        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da Empresa deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; }
        public string Senha { get; set; }


        [StringLength(30)]
        public int Cep { get; set; }
        public string Logadouro { get; set; }
        public string Rua { get; set; }

        [StringLength(30)]
        public string Bairro { get; set; }
        public string Estado { get; set; }

        [StringLength(30)]
        public int Numero { get; set; }
        public string Complemento { get; set; }
    }
}
