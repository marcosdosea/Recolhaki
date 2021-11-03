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
    public class ManterPessoaServiceTests
    {
        private recolhakiContext _context;
        private IManterPessoaService _manterPessoaService;

        [TestMethod()]
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

            _manterPessoaService = new ManterPessoaService(_context);
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _manterPessoaService.Inserir(new Pessoa() { IdPessoa = 4, Nome = "Graciliano Ramos" });
            // Assert
            Assert.AreEqual(4, _manterPessoaService.ObterTodos().Count());
            var pessoa = _manterPessoaService.Obter(4);
            Assert.AreEqual("Graciliano Ramos", pessoa.Nome);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var pessoa = _manterPessoaService.Obter(3);
            pessoa.Nome = "Paulo Coelho";
            
            _manterPessoaService.Editar(pessoa);
            pessoa = _manterPessoaService.Obter(3);
            Assert.AreEqual("Paulo Coelho", pessoa.Nome);
            
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _manterPessoaService.Remover(2);
            // Assert
            Assert.AreEqual(2, _manterPessoaService.ObterTodos().Count());
            var pessoa = _manterPessoaService.Obter(2);
            Assert.AreEqual(null, pessoa);
        }
        
        /*[TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaPessoa = _manterPessoaService.ObterTodos();
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
            var listaPessoa = _manterPessoaService.ObterTodosOrdenadoPorNome();
            Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoa);
            Assert.AreNotEqual(0, listaPessoa.Count());
            Assert.AreEqual(3, listaPessoa.First().IdPessoa);
            Assert.AreEqual("Gleford Myers", listaPessoa.First().Nome);
        }*/
        
        [TestMethod()]
        public void ObterTest()
        {
            var pessoa = _manterPessoaService.Obter(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Machado de Assis", pessoa.Nome);
        }

        [TestMethod()]
        public void ObterPorNomeTest()
        {
            var pessoas = _manterPessoaService.ObterPorNome("Machado");
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(1, pessoas.Count());
            Assert.AreEqual("Machado de Assis", pessoas.First().Nome);
        }

        /*[TestMethod()]
        public void ObterPorNomeContendoTest()
        {
            var pessoas = _manterPessoaService.ObterPorNomeContendo("Sommervile");
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(1, pessoas.Count());
            Assert.AreEqual("Ian S. Sommervile", pessoas.First().Nome);
        }*/

        /*[TestMethod()]
        public void ObterPorNomeOrdenadoDescendignTest()
        {
            var pessoas = _manterPessoaService.ObterPorNomeOrdenadoDescending("Ia");
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(1, pessoas.Count());
            Assert.AreEqual("Ian S. Sommervile", pessoas.First().Nome);
        }*/
        
    }
}