using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class MaterialreciclavelDTO
    {
        public int IdMaterialReciclavel { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public float PesoAproximado { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public string StatusColeta { get; set; }
        public string StatusNotificacao { get; set; }
        public DateTime? DataColeta { get; set; }
        public DateTime? DataNotificacao { get; set; }
        public DateTime? DataManifestacaoInteresse { get; set; }
        public int? IdPessoaColetor { get; set; }
        public int IdPessoaDoador { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
