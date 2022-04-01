using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class EmpresaServiceTests
    {
        private recolhakiContext _context;
        private IEmpresaService _empresaService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<recolhakiContext>();
           
            var options = builder.Options;

            _context = new recolhakiContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var empresaes = new List<Empresa>
                {
                    new Empresa { IdEmpresa = 1, Nome = "Machado de Assis", Cep = 64019700},
                    new Empresa { IdEmpresa = 2, Nome = "Ian S. Sommervile", Cep = 69316002},
                    new Empresa { IdEmpresa = 3, Nome = "Gleford Myers", Cep = 94450-530},
                };

            _context.AddRange(empresaes);
            _context.SaveChanges();

            _empresaService = new EmpresaService(_context);
        }

		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_empresaService.Inserir(new Empresa() { IdEmpresa = 4, Nome = "Graciliano Ramos", Cep = 49530000 });
			// Assert
			Assert.AreEqual(4, _empresaService.ObterTodos().Count());
			var empresa = _empresaService.Obter(4);
			Assert.AreEqual("Graciliano Ramos", empresa.Nome);
			Assert.AreEqual(49530000, empresa.Cep);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var empresa = _empresaService.Obter(3);
			empresa.Nome = "Paulo Coelho";
			empresa.Cep = 58103 - 766;
			_empresaService.Editar(empresa);
			empresa = _empresaService.Obter(3);
			Assert.AreEqual("Paulo Coelho", empresa.Nome);
			Assert.AreEqual(58103 - 766, empresa.Cep);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_empresaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _empresaService.ObterTodos().Count());
			var empresa = _empresaService.Obter(2);
			Assert.AreEqual(null, empresa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaempresa = _empresaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaempresa, typeof(IEnumerable<Empresa>));
			Assert.IsNotNull(listaempresa);
			Assert.AreEqual(3, listaempresa.Count());
			Assert.AreEqual(1, listaempresa.First().IdEmpresa);
			Assert.AreEqual("Machado de Assis", listaempresa.First().Nome);
		}


		[TestMethod()]
		public void ObterTest()
		{
			var empresa = _empresaService.Obter(1);
			Assert.IsNotNull(empresa);
			Assert.AreEqual("Machado de Assis", empresa.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var empresa = _empresaService.ObterPorNome("Machado");
			Assert.IsNotNull(empresa);
			Assert.AreEqual(1, empresa.Count());
			Assert.AreEqual("Machado de Assis", empresa.First().Nome);
		}

		

		
	}
}