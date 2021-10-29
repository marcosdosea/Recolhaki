using System;
using System.Collections.Generic;

namespace Core.DTO
{
    internal class DisponibilizarMaterialDTO
    {
        public int Tipo { get; set; }
        public float Peso { get; set; }
        public string nome { get; set; }
        public DateTime dataManifestacaoInteresse { get; set; }

        public virtual ICollection<Doacaomaterialreciclavel> Doacaomaterialreciclavel { get; set; }

    }
}
