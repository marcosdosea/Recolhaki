using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
namespace Service.Tests
{
	[TestClass()]
	public class ColetorServiceTests
	{
		private recolhakiContext _context;
		private ColetorService _ColetorService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<recolhakiContext>();
			builder.UseInMemoryDatabase("recolhaki");
			var options = builder.Options;

			_context = new recolhakiContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var pessoa = new List<Pessoa>
				{
					new Pessoa { IdPessoa = 3, Nome = "Ayla Miller"},
					new Pessoa { IdPessoa = 5, Nome = "teste"},

				};

			_context.AddRange(pessoa);
			_context.SaveChanges();

			_ColetorService = new ColetorService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_ColetorService.Inserir(new Pessoa() { IdPessoa = 6, Nome = "Graciliano Ramos" });
			// Assert
			Assert.AreEqual(6, _ColetorService.ObterTodos().Count());
			var pessoa = _ColetorService.Obter(6);
			Assert.AreEqual("Graciliano Ramos", pessoa.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var pessoa = _ColetorService.Obter(3);
			pessoa.Nome = "Ayla Miller";

			_ColetorService.Editar(pessoa);
			pessoa = _ColetorService.Obter(3);
			Assert.AreEqual("Ayla Miller", pessoa.Nome);

		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_ColetorService.Remover(5);
			// Assert
			Assert.AreEqual(5, _ColetorService.ObterTodos().Count());
			var pessoa = _ColetorService.Obter(3);
			Assert.AreEqual(null, pessoa);
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
			var pessoa = _ColetorService.Obter(3);
			Assert.IsNotNull(pessoa);
			Assert.AreEqual("Ayla Miller", pessoa.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var pessoa = _ColetorService.ObterPorNome("Ayla");
			Assert.IsNotNull(pessoa);
			//Assert.AreEqual(3, pessoa.Count());
			Assert.AreEqual("Ayla Miller", pessoa.First().Nome);
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