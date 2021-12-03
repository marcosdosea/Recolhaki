using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Empresacoletor
    {
        public int IdEmpresa { get; set; }
        public int IdPessoa { get; set; }
        public DateTime DataAutorizacao { get; set; }
        public string Status { get; set; }
        public int PrazoColetaHoras { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
