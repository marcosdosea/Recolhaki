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
    public class ManterColetorService : IManterColetorService
    {
        private readonly recolhakiContext _context;


        public ManterColetorService(recolhakiContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Inserir novo Coletor
        /// </summary>
        /// <param name="pessoa">dados do coletor</param>
        /// <returns>retorna o IdPessoa gerado</returns>
        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
            
        }
        /// <summary>
        /// Atualiza os dados do coletor na base de dados
        /// </summary>
        /// <param name="pessoa">dados do coletor</param>
        public void Editar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();

        }

        /// <summary>
        /// Buscar coletor pelo id na base de dados
        /// </summary>
        /// <param name="IdPessoa">id do coletor que será buscado</param>
        /// <returns>Os dados do coletor ou nulo quando não encontrado</returns>
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

        public IEnumerable<ManterColetorDTO> ObterPorNomeOrdenadoDescendign(string nome)
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
        /// Remove o coletor da base de dados
        /// </summary>
        /// <param name="IdPessoa">a ser removido</param>
        public void Remover(int IdPessoa)
        {
            var pessoa = _context.Pessoa.Find(IdPessoa);
            _context.Remove(pessoa);
            _context.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
