using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class ManterColetorServiceTests
    {
		private recolhakiContext _context;
		private IManterColetorService _manterColetorService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<recolhakiContext>();
			
			var options = builder.Options;

			_context = new recolhakiContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var pessoa = new List<Pessoa>
				{
					new Pessoa { IdPessoa = 1, Nome = "Machado de Assis"},
					new Pessoa { IdPessoa = 2, Nome = "Ian S. Sommervile"},
					new Pessoa { IdPessoa = 3, Nome = "Gleford Myers"},
				};

			_context.AddRange(pessoa);
			_context.SaveChanges();

			_manterColetorService = new ManterColetorService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_manterColetorService.Inserir(new Pessoa() { IdPessoa = 4, Nome = "Graciliano Ramos" });
			// Assert
			Assert.AreEqual(4, _manterColetorService.ObterTodos().Count());
			var autor = _manterColetorService.Obter(4);
			Assert.AreEqual("Graciliano Ramos", autor.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var autor = _manterColetorService.Obter(3);
			autor.Nome = "Paulo Coelho";
			
			_manterColetorService.Editar(autor);
			autor = _manterColetorService.Obter(3);
			Assert.AreEqual("Paulo Coelho", autor.Nome);
			
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_manterColetorService.Remover(2);
			// Assert
			Assert.AreEqual(2, _manterColetorService.ObterTodos().Count());
			var autor = _manterColetorService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		/*[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPessoa = _manterColetorService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoa);
			Assert.AreEqual(3, listaPessoa.Count());
			Assert.AreEqual(1, listaPessoa.First().IdPessoa);
			Assert.AreEqual("Machado de Assis", listaPessoa.First().Nome);
		}*/

		/*[TestMethod()]
		public void ObterTodosOrdenadoPorNomeTest()
		{
			var listaPessoa = _manterColetorService.ObterTodosOrdenadoPorNome();
			Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoa);
			Assert.AreNotEqual(0, listaPessoa.Count());
			Assert.AreEqual(3, listaPessoa.First().IdAutor);
			Assert.AreEqual("Gleford Myers", listaPessoa.First().Nome);
		}*/

		[TestMethod()]
		public void ObterTest()
		{
			var autor = _manterColetorService.Obter(1);
			Assert.IsNotNull(autor);
			Assert.AreEqual("Machado de Assis", autor.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var autores = _manterColetorService.ObterPorNome("Machado");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Machado de Assis", autores.First().Nome);
		}

		/*[TestMethod()]
		public void ObterPorNomeContendoTest()
		{
			var autores = _manterColetorService.ObterPorNomeContendo("Sommervile");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Ian S. Sommervile", autores.First().Nome);
		}*/

		/*[TestMethod()]
		public void ObterPorNomeOrdenadoDescendingTest()
		{
			var autores = _manterColetorService.ObterPorNomeOrdenadoDescending("Ia");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Ian S. Sommervile", autores.First().Nome);
		}*/
	}
}

