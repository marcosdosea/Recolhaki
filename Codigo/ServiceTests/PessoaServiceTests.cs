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
    public class PessoaServiceTests
    {
        private recolhakiContext _context;
        private IPessoaService _pessoaService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<recolhakiContext>();

            var options = builder.Options;

            _context = new recolhakiContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var pessoas = new List<Pessoa>
                {
                    new Pessoa { IdPessoa = 1, Nome = "Machado de Assis", Cep = 64019700},
                    new Pessoa { IdPessoa = 2, Nome = "Ian S. Sommervile", Cep = 69316002},
                    new Pessoa { IdPessoa = 3, Nome = "Gleford Myers", Cep = 94450-530},
                };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var pessoa = _pessoaService.Obter(3);
            pessoa.Nome = "Paulo Coelho";
            pessoa.Cep = 58103 - 766;
            _pessoaService.Editar(pessoa);
            pessoa = _pessoaService.Obter(3);
            Assert.AreEqual("Paulo Coelho", pessoa.Nome);
            Assert.AreEqual(58103 - 766, pessoa.Cep);
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _pessoaService.Inserir(new Pessoa() { IdPessoa = 4, Nome = "Graciliano Ramos", Cep = 49530000 });
            // Assert
            Assert.AreEqual(4, _pessoaService.ObterTodos().Count());
            var pessoa = _pessoaService.Obter(4);
            Assert.AreEqual("Graciliano Ramos", pessoa.Nome);
            Assert.AreEqual(49530000, pessoa.Cep);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var pessoa = _pessoaService.Obter(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Machado de Assis", pessoa.Nome);
        }

        [TestMethod()]
        public void ObterPorNomeTest()
        {
            var pessoa = _pessoaService.ObterPorNome("Machado");
            Assert.IsNotNull(pessoa);
            Assert.AreEqual(1, pessoa.Count());
            Assert.AreEqual("Machado de Assis", pessoa.First().Nome);
        }

        [TestMethod()]
        public void ObterPorNomeOrdenadoDescendignTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listapessoa = _pessoaService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listapessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listapessoa);
            Assert.AreEqual(3, listapessoa.Count());
            Assert.AreEqual(1, listapessoa.First().IdPessoa);
            Assert.AreEqual("Machado de Assis", listapessoa.First().Nome);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _pessoaService.Remover(2);
            // Assert
            Assert.AreEqual(2, _pessoaService.ObterTodos().Count());
            var pessoa = _pessoaService.Obter(2);
            Assert.AreEqual(null, pessoa);
        }
    }
}