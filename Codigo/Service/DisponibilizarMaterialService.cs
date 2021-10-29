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
        public Doacaomaterialreciclavel getMaterial(int IdDoacaoMaterialReciclavel)
        {
            return _context.Doacaomaterialreciclavel.Find(IdDoacaoMaterialReciclavel);
        }

        /// <summary>
        /// Inserir material reciclável
        /// </summary>
        /// <param name="doacaomaterialreciclavel">dados do material reciclável</param>
        /// <returns>retorna o IdDoacaoMaterialReciclavel gerado</returns>
        public int Inserir(Doacaomaterialreciclavel doacaomaterialreciclavel)
        {
            _context.Add(doacaomaterialreciclavel);
            _context.SaveChanges();
            return doacaomaterialreciclavel.IdDoacaoMaterialReciclavel;
        }

        public IEnumerable<Doacaomaterialreciclavel> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doacaomaterialreciclavel> ObterTodos()
        {
            return _context.Doacaomaterialreciclavel;
        }



        /// <summary>
        /// Remove um material reciclável da base de dados
        /// </summary>
        /// <param name="IdDoacaoMaterialReciclavel">a ser removido</param>
        public void Remover(int IdDoacaoMaterialReciclavel)
        {
            var doacaoMaterial = _context.Doacaomaterialreciclavel.Find(IdDoacaoMaterialReciclavel);
            _context.Remove(doacaoMaterial);
            _context.SaveChanges();
        }
    }
}
