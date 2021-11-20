using Core;
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
		private EmpresaService _EmpresaService;

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
			var empresa = new List<Pessoa>
				{
					new Pessoa { IdPessoa = 3, Nome = "Ayla Miller"},
					new Pessoa { IdPessoa = 5, Nome = "teste"},

				};

			_context.AddRange(empresa);
			_context.SaveChanges();

			_EmpresaService = new EmpresaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_EmpresaService.Inserir(new Pessoa() { IdPessoa = 6, Nome = "Graciliano Ramos" });
			// Assert
			Assert.AreEqual(6, _EmpresaService.ObterTodos().Count());
			var empresa = _EmpresaService.Obter(6);
			Assert.AreEqual("Graciliano Ramos", empresa.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var empresa = _EmpresaService.Obter(3);
			empresa.Nome = "Ayla Miller";

			_EmpresaService.Editar(empresa);
			empresa = _EmpresaService.Obter(3);
			Assert.AreEqual("Ayla Miller", empresa.Nome);

		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_EmpresaService.Remover(5);
			// Assert
			Assert.AreEqual(5, _EmpresaService.ObterTodos().Count());
			var empresa = _EmpresaService.Obter(3);
			Assert.AreEqual(null, empresa);
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
			var empresa = _EmpresaService.Obter(3);
			Assert.IsNotNull(empresa);
			Assert.AreEqual("Ayla Miller", empresa.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var empresa = _EmpresaService.ObterPorNome("Ayla");
			Assert.IsNotNull(empresa);
			//Assert.AreEqual(3, pessoa.Count());
			Assert.AreEqual("Ayla Miller", empresa.First().Nome);
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