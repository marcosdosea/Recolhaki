using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IEmpresaService
    {
        void Editar(Empresa empresa);
        int Inserir(Empresa empresa);
        Empresa Obter(int IdEmpresa);
        IEnumerable<Empresa> ObterPorNome(string nome);
        IEnumerable<Empresa> ObterTodos();
        void Remover(int IdEmpresa);
        IEnumerable<EmpresaDTO> ObterPorNomeOrdenadoDescendign(string nome);

        
    }
}
