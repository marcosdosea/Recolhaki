using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DisponibilizarMaterialService : IDisponibilizarMaterialService
    {
        private readonly recolhakiContext _context;

        public DisponibilizarMaterialService(recolhakiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Editar material reciclável
        /// </summary>
        /// <param name="doacaomaterialreciclavel">dados do material reciclável</param>
        public void Editar(Doacaomaterialreciclavel doacaomaterialreciclavel)
        {
            _context.Update(doacaomaterialreciclavel);
            _context.SaveChanges();
        }

        /// <summary>
        /// buscar material reciclável
        /// </summary>
        /// <param name="IdDoacaoMaterialReciclavel">dados do material reciclável</param>
        /// <returns>retorna o material reciclável ou nulo quando não for encontrado</returns>
        public Doacaomaterialreciclavel Obter(int IdDoacaoMaterialReciclavel)
        {
            return _context.Doacaomaterialreciclavel.Find(IdDoacaoMaterialReciclavel);
        }

        /// <summary>
        /// Insere um material reciclável
        /// </summary>
        /// <param name="doacaomaterialreciclavel">dados do material reciclável</param>
        /// <returns>retorna o IdDoacaoMaterialReciclavel gerado</returns>
        public int Inserir(Doacaomaterialreciclavel doacaomaterialreciclavel)
        {
            _context.Add(doacaomaterialreciclavel);
            _context.SaveChanges();
            return doacaomaterialreciclavel.IdDoacaoMaterialReciclavel;
        }

        /// <summary>
        /// Consulta genérica aos dados da doação
        /// </summary>
        /// <returns></returns>
        private IQueryable<Doacaomaterialreciclavel> GetQuery()
        {
            IQueryable<Doacaomaterialreciclavel> tb_doacaomaterialreciclavel = _context.Doacaomaterialreciclavel;

            var query = from doacaomaterialreciclavel in tb_doacaomaterialreciclavel 
                        select doacaomaterialreciclavel;
            
            return query;
        }

        public IEnumerable<Doacaomaterialreciclavel> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtém todos as doações 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doacaomaterialreciclavel> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Retorna o número de doações cadastradas
        /// </summary>
        /// <returns></returns>
        public int GetNumeroDoacoes()
        {
            return _context.Doacaomaterialreciclavel.Count();
        }



        /// <summary>
        /// Remove um material reciclável da base de dados
        /// </summary>
        /// <param name="IdDoacaoMaterialReciclavel">a ser removido identificado da doação</param>
        public void Remover(int IdDoacaoMaterialReciclavel)
        {
            var _doacaoMaterial = _context.Doacaomaterialreciclavel.Find(IdDoacaoMaterialReciclavel);
            _context.Doacaomaterialreciclavel.Remove(_doacaoMaterial);
            _context.SaveChanges();
        }
    }
}
