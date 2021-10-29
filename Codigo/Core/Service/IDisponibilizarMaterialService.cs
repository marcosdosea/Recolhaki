using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDisponibilizarMaterialService
    {
        int Inserir(Doacaomaterialreciclavel doacaomaterialreciclavel);
        void Remover(int IdDoacaoMaterialReciclavel);
        void Editar(Doacaomaterialreciclavel doacaomaterialreciclavel);
        IEnumerable<Doacaomaterialreciclavel> ObterPorNome(string nome);
        IEnumerable<Doacaomaterialreciclavel> ObterTodos();
        Doacaomaterialreciclavel getMaterial(int IdDoacaoMaterialReciclavel);
    }
}
