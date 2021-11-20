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
    public class ManterEmpresaService : IManterEmpresaService
    {
        private readonly recolhakiContext _context;


        public ManterEmpresaService(recolhakiContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Inserir nova Empresa
        /// </summary>
        /// <param name="empresa">dados da Empresa</param>
        /// <returns>retorna o IdEmpresa gerado</returns>
        public int Inserir(Empresa Empresa)
        {
            _context.Add(Empresa);
            _context.SaveChanges();
            return Empresa.IdEmpresa;
            
        }
        /// <summary>
        /// Atualiza os dados da Empresa na base de dados
        /// </summary>
        /// <param name="Empresa">dados da Empresa</param>
        public void Editar(Empresa Empresa)
        {
            _context.Update(Empresa);
            _context.SaveChanges();

        }

        /// <summary>
        /// Buscar Empresa pelo id na base de dados
        /// </summary>
        /// <param name="IdEmpresa">id da Empresa que será buscado</param>
        /// <returns>Os dados da Empresa ou nulo quando não encontrado</returns>
        public Empresa Obter(int IdEmpresa)
        {
            return _context.Empresa.Find(IdEmpresa);

        }

        public IEnumerable<Empresa> ObterPorNome(string nome)
        {

            //var query = from Empresa in _context.Empresa
            //            orderby Empresa.Nome
            //            select Empresa;
            //return query;
            throw new NotImplementedException();
        }

        public IEnumerable<ManterEmpresaDTO> ObterPorNomeOrdenadoDescendign(string nome)
        {
            //var query = from Empresa in _context.Empresa
            //             where Empresa.Nome.StartsWith(nome)
            //            orderby Empresa.Nome descending
            //           select new ManterColetorDTO
            //           {
            //                Nome = Empresa.Nome
            //            };
            //  return query;
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            return _context.Empresa;
        }

        /// <summary>
        /// Remove a Empresa da base de dados
        /// </summary>
        /// <param name="IdEmpresa">a ser removido</param>
        public void Remover(int IdEmpresa)
        {
            var Empresa = _context.Empresa.Find(IdEmpresa);
            _context.Remove(Empresa);
            _context.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
