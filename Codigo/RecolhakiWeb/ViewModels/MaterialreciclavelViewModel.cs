using System;
using System.ComponentModel.DataAnnotations;

namespace RecolhakiWeb.ViewModels
{
    public class MaterialreciclavelViewModel
    {

        [Required]
        [Key]
        [Display(Name ="Código")]
        public int IdMaterialReciclavel { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "CNPJ")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "A descrição deve ter emtre 20 e 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public float PesoAproximado { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date, ErrorMessage = "Data valida requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataSolicitacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string StatusColeta { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string StatusNotificacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date, ErrorMessage = "Data valida requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataColeta { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date, ErrorMessage = "Data valida requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataNotificacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date, ErrorMessage = "Data valida requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataManifestacaoInteresse { get; set; }

        public int? IdPessoaColetor { get; set; }
        public int IdPessoaDoador { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
