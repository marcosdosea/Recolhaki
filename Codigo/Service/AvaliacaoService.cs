using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly recolhakiContext _context;

        public AvaliacaoService (recolhakiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma avaliação
        /// </summary>
        /// <param name="avaliacao">dados da avaliação</param>
        /// <returns>retorna o IdAvaliaca gerado</returns>
        public int Inserir(Avaliacao avaliacao)
        {
            _context.Add(avaliacao);
            _context.SaveChanges();
            return avaliacao.IdAvaliacao;
        }

        /// <summary>
        /// Consulta genérica aos dados de avaliação
        /// </summary>
        /// <returns></returns>
        private IQueryable<Avaliacao> GetQuery()
        {
            IQueryable<Avaliacao> tb_avaliacao = _context.Avaliacao;

            var query = from avaliacao in tb_avaliacao
                        select avaliacao;

            return query;
        }

        public int InserirEmoje(Avaliacao idEmoje)
        {
            throw new NotImplementedException();
        }

        public Avaliacao Obter(int IdAvaliacao)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtém todos as avaliações 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Avaliacao> ObterTodos()
        {
            return GetQuery();
        }

        public void Remover(int IdAvaliacao)
        {
            var _avaliacao = _context.Avaliacao.Find(IdAvaliacao);
            _context.Avaliacao.Remove(_avaliacao);
            _context.SaveChanges();

        }


        /// <summary>
        /// Editar avaliação
        /// </summary>
        /// <param name="avaliacao">dados da avaliação</param>
        public void Editar(Avaliacao avaliacao)
        {
            _context.Update(avaliacao);
            _context.SaveChanges();
        }

    }
}
