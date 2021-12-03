using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Materialreciclavel
    {
        public Materialreciclavel()
        {
            Avaliacao = new HashSet<Avaliacao>();
        }

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

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Pessoa IdPessoaColetorNavigation { get; set; }
        public virtual Pessoa IdPessoaDoadorNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
