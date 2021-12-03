using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly recolhakiContext _context;

        public EmpresaService(recolhakiContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Atualiza os dados da Empresa na base de dados
        /// </summary>
        /// <param name="empresa">dados da empresa</param>
        public void Editar(Empresa empresa)
        {
            _context.Update(empresa);
            _context.SaveChanges();
        }
        /// <summary>
        /// Inserir nova Empresa
        /// </summary>
        /// <param name="empresa">dados da empresa</param>
        /// <returns>retorna o IdEmpresa gerado</returns>
        public int Inserir(Empresa empresa)
        {
            _context.Add(empresa);
            _context.SaveChanges();
            return empresa.IdEmpresa;
        }
        /// <summary>
        /// Buscar empresa pelo id na base de dados
        /// </summary>
        /// <param name="IdEmpresa">id da empresa que será buscado</param>
        /// <returns>Os dados da empresa ou nulo quando não encontrado</returns>
        public Empresa Obter(int IdEmpresa)
        {
            return _context.Empresa.Find(IdEmpresa);

        }

        public IEnumerable<Empresa> ObterPorNome(string nome)
        {

            var query = from empresa in _context.Empresa
                        orderby empresa.Nome
                       select empresa;
            return query;
        }

        public IEnumerable<EmpresaDTO> ObterPorNomeOrdenadoDescendign(string nome)
        {
            var query = from empresa in _context.Empresa
                         where empresa.Nome.StartsWith(nome)
                        orderby empresa.Nome descending
                      select new EmpresaDTO
                       {
                            Nome = empresa.Nome
                        };
              return query;
            
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            return _context.Empresa;
        }

        /// <summary>
        /// Remove a empresa da base de dados
        /// </summary>
        /// <param name="IdPessoa">a ser removido</param>

        public void Remover(int IdEmpresa)
        {
            var empresa = _context.Empresa.Find(IdEmpresa);
            _context.Remove(empresa);
            _context.SaveChanges();
        }
    }
}
