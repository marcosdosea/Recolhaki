using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvaliacaoService
    {
        int Inserir(Avaliacao avaliacao);

        int InserirEmoje(Avaliacao idEmoje);

        void Editar(Avaliacao avaliacao);

        Avaliacao Obter(int IdAvaliacao);

        IEnumerable<Avaliacao> ObterTodos();

        void Remover(int IdAvaliacao);
    }
}
