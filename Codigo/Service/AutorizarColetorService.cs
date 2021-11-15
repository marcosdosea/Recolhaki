using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AutorizarColetorService : IAutorizarColetorService
    {
        private readonly recolhakiContext _context;

       
        public AutorizarColetorService(recolhakiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza os dados do coletor na base de dados
        /// </summary>
        /// <param name="coletor">dados do coletor</param>
        public void Editar(Autorizacaocoletor autorizacaocoletor)
        {
            _context.Update(autorizacaocoletor);
            _context.SaveChanges();
        }
        /// <summary>
        /// Inserir novo Coletor
        /// </summary>
        /// <param name="coletor">dados do coletor</param>
        /// <returns>retorna o IdPessoa gerado</returns>
        public int Inserir(Autorizacaocoletor autorizacaocoletor)
        {
            _context.Add(autorizacaocoletor);
           _context.SaveChanges();
            return autorizacaocoletor.ColetorIdColetor;
        }
        /// <summary>
        /// Buscar coletor pelo id na base de dados
        /// </summary>
        /// <param name="PessoaIdPessoa">id do coletor que será buscado</param>
        /// <returns>Os dados do coletor ou nulo quando não encontrado</returns>
        public Autorizacaocoletor Obter(int PessoaIdPessoa)
        {
            return _context.Autorizacaocoletor.Find(PessoaIdPessoa);
        }

        public IEnumerable<Autorizacaocoletor> ObterPorNome(string nome)
        {
            var query = from coletor in _context.Autorizacaocoletor
                        orderby coletor.StatusAutorizacao
                        select coletor;
            return query;
        }

        public IEnumerable<Autorizacaocoletor> ObterTodos()
        {
            return _context.Autorizacaocoletor;
        }

        public void Remover(int PessoaIdPessoa)
        {
            var coletor = _context.Autorizacaocoletor.Find(PessoaIdPessoa);
            _context.Remove(coletor);
            _context.SaveChanges();
        }

       
    }
}
