using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IMaterialreciclavelService
    {
        void Editar(Materialreciclavel materialreciclavel);
        int Inserir(Materialreciclavel materialreciclavel);
        Materialreciclavel Obter(int IdMaterialReciclavel);
        IEnumerable<Materialreciclavel> ObterTodos();
        void Remover(int IdMaterialReciclavel);
    }
}
