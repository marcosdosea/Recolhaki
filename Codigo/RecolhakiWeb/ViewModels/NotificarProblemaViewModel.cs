using System;
using System.ComponentModel.DataAnnotations;

namespace RecolhakiWeb.ViewModels
{
    public class NotificarProblemaViewModel
    {

        [Display(Name = "Código")]
        [Required]
        [Key]
        public int IdPessoa { get; set; }


        public int IdNotificacao { get; set; }
        public string NomeMaterialReciclavel { get; set; }
        public DateTime DataManifestacaoInteresse { get; set; }

        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 80 caracteres")]

        public string Nome { get; set; }

    }
}
