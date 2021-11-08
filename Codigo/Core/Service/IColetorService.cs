using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IColetorService
    {
        void Editar(Pessoa pessoa);
        int Inserir(Pessoa pessoa);
        Pessoa Obter(int IdPessoa);
        IEnumerable<Pessoa> ObterPorNome(string nome);
        IEnumerable<Pessoa> ObterTodos();
        void Remover(int IdPessoa);
        IEnumerable<ColetorDTO> ObterPorNomeOrdenadoDescendign(string nome);

        
    }
}
