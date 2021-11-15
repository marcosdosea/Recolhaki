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
    public class NotificarProblemaServiceTests
    {

        private recolhakiContext _context;
        private INotificarProblemaService _NotificarProblemaService;

        [TestMethod()]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<recolhakiContext>();
            builder.UseInMemoryDatabase("recolhaki");
            var options = builder.Options;

            _context = new recolhakiContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var notificacao = new List<Notificacao>
                {
                    new Notificacao { IdPessoa = 1, Nome = "Machado de Assis"},
                    new Notificacao { IdPessoa = 2, Nome = "Ian S. Sommervile"},
                    new Notificacao { IdPessoa = 3, Nome = "Gleford Myers"},
                };

            _context.AddRange(notificacao);
            _context.SaveChanges();

            _NotificarProblemaService = new NotificarProblemaService(_context);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var notificacao = _NotificarProblemaService.Obter(3);
            notificacao.Nome = "Paulo Coelho";

            _NotificarProblemaService.Editar(notificacao);
            notificacao = _NotificarProblemaService.Obter(3);
            Assert.AreEqual("Paulo Coelho", notificacao.Nome);
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _NotificarProblemaService.Inserir(new Notificacao() { IdPessoa = 4, Nome = "Graciliano Ramos" });
            // Assert
            Assert.AreEqual(4, _NotificarProblemaService.ObterTodos().Count());
            var notificacao = _NotificarProblemaService.Obter(4);
            Assert.AreEqual("Graciliano Ramos", notificacao.Nome);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var notificacao = _NotificarProblemaService.Obter(1);
            Assert.IsNotNull(notificacao);
            Assert.AreEqual("Machado de Assis", notificacao.Nome);
        }

        [TestMethod()]
        public void ObterPorNomeTest()
        {
            var notificacao = _NotificarProblemaService.ObterPorNome("Machado");
            Assert.IsNotNull(notificacao);
            Assert.AreEqual(1, notificacao.Count());
            Assert.AreEqual("Machado de Assis", notificacao.First().Nome);
        }

        /*[TestMethod()]
        public void ObterTodosTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _NotificarProblemaService.Remover(2);
            // Assert
            Assert.AreEqual(2, _NotificarProblemaService.ObterTodos().Count());
            var notificacao = _NotificarProblemaService.Obter(2);
            Assert.AreEqual(null, notificacao);
        }
    }
}