using System;
using System.ComponentModel.DataAnnotations;

namespace RecolhakiWeb.ViewModels
{
    public class DisponibilizarMaterialViewModel
    {

        [Required]
        [Key]
        public int IdDoacaoMaterialReciclavel { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do coletor deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do coletor deve ter entre 5 e 50 caracteres")]
        public float Peso { get; set; }

        public DateTime DataManifestacaoInteresse { get; set; }

    }
}
