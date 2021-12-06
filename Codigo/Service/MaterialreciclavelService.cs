using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MaterialreciclavelService : IMaterialreciclavelService
    {
        private readonly recolhakiContext _context;

        public MaterialreciclavelService(recolhakiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza os dados do material reciclavel na base de dados
        /// </summary>
        /// <param name="materialreciclavel">dados do material reciclavel</param>
        public void Editar(Materialreciclavel materialreciclavel)
        {
            _context.Update(materialreciclavel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Inserir um novo material reciclavel
        /// </summary>
        /// <param name="materialreciclavel">dados do material reciclavel</param>
        /// <returns>retorna o IdMaterialReciclavel gerado</returns>
        public int Inserir(Materialreciclavel materialreciclavel)
        {
            _context.Add(materialreciclavel);
            _context.SaveChanges();
            return materialreciclavel.IdMaterialReciclavel;
        }

        /// <summary>
        /// Buscar material reciclavel pelo id na base de dados
        /// </summary>
        /// <param name="IdMaterialReciclavel">id do material reciclavel que será buscado</param>
        /// <returns>Os dados do material reciclavel ou nulo quando não encontrado</returns>
        public Materialreciclavel Obter(int IdMaterialReciclavel)
        {
            return _context.Materialreciclavel.Find(IdMaterialReciclavel);
        }

        public IEnumerable<Materialreciclavel> ObterTodos()
        {
            return _context.Materialreciclavel;
        }

        /// <summary>
        /// Remove um material reciclavel da base de dados
        /// </summary>
        /// <param name="IdMaterialReciclavel">a ser removido</param>
        public void Remover(int IdMaterialReciclavel)
        {
            var materialreciclavel = _context.Materialreciclavel.Find(IdMaterialReciclavel);
            _context.Remove(materialreciclavel);
            _context.SaveChanges();
        }
    }
}
