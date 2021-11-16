using Core;
using System.ComponentModel.DataAnnotations;

namespace RecolhakiWeb.ViewModels
{
    public class AvaliacaoViewModel
    {

        [Display(Name = "Código")]
        [Required]
        [Key]
        public int IdAvaliacao { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(500, MinimumLength = 25, ErrorMessage = "A descrição deve ter entre 25 e 500 caracteres")]
        public string Descricao { get; set; }


        [Display(Name = "Emoje")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdEmoje { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        public int PessoaIdPessoa { get; set; }


    }
}
