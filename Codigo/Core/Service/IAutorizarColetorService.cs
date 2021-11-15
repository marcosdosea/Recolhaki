using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAutorizarColetorService
    {
        void Editar(Autorizacaocoletor autorizacaocoletor);
        int Inserir(Autorizacaocoletor autorizacaocoletor);
        Autorizacaocoletor Obter(int ColetorIdColetor);
  
        IEnumerable<Autorizacaocoletor> ObterPorNome(string nome);
        IEnumerable<Autorizacaocoletor> ObterTodos();
        void Remover(int ColetorIdColetor);
       
    }
}
