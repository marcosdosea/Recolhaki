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
        /// Inserir novo registro de Empresa
        /// </summary>
        /// <param name="pessoa">dados da empresa</param>
        /// <returns>retorna o IdPessoa gerado</returns>
        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;

        }
        /// <summary>
        /// Atualiza os dados da empresa na base de dados
        /// </summary>
        /// <param name="pessoa">dados do coletor</param>
        public void Editar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();

        }

        /// <summary>
        /// Buscar empresa pelo id na base de dados
        /// </summary>
        /// <param name="IdPessoa">id da empresa que será buscado</param>
        /// <returns>Os dados da empresa ou nulo quando não encontrado</returns>
        public Pessoa Obter(int IdPessoa)
        {
            return _context.Pessoa.Find(IdPessoa);

        }

        public IEnumerable<Pessoa> ObterPorNome(string nome)
        {

            //var query = from pessoa in _context.Pessoa
            //            orderby pessoa.Nome
            //            select pessoa;
            //return query;
            throw new NotImplementedException();
        }

        public IEnumerable<EmpresaDTO> ObterPorNomeOrdenadoDescendign(string nome)
        {
            //var query = from pessoa in _context.Pessoa
            //             where pessoa.Nome.StartsWith(nome)
            //            orderby pessoa.Nome descending
            //           select new ManterColetorDTO
            //           {
            //                Nome = pessoa.Nome
            //            };
            //  return query;
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return _context.Pessoa;
        }

        /// <summary>
        /// Remove a empresa da base de dados
        /// </summary>
        /// <param name="IdPessoa">a ser removido</param>
        public void Remover(int IdPessoa)
        {
            var pessoa = _context.Pessoa.Find(IdPessoa);
            _context.Remove(pessoa);
            _context.SaveChanges();

        }

        IEnumerable<EmpresaDTO> IEmpresaService.ObterPorNomeOrdenadoDescendign(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
