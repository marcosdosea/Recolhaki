using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.ViewModels
{
    public class PessoaViewModel
    {
        [Required]
        [Key]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da pessoa deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Email")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Cep")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Cidade")]
        public string Cidade { get; set; }




        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Complemento")]
        public string Complemento { get; set; }

    }
}
