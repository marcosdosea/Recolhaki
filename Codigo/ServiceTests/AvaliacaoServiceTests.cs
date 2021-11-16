using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass()]
    public class AvaliacaoServiceTests
    {
        private recolhakiContext _context;
        private IAvaliacaoService _avaliacaoService;

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
            var avaliacao = new List<Avaliacao>
                {
                    new Avaliacao { IdAvaliacao = 1, Descricao = "Media"},
                    new Avaliacao { IdAvaliacao = 2, IdEmoje = 2},
                    new Avaliacao { IdAvaliacao = 3, Descricao = "Boa"},
                };

            _context.AddRange(avaliacao);
            _context.SaveChanges();

            _avaliacaoService = new AvaliacaoService(_context);
        }

        [TestMethod()]
        public void AvaliacaoServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _avaliacaoService.Inserir(new Avaliacao() { IdAvaliacao = 4, Descricao = "Boa" });
            // Assert
            Assert.AreEqual(4, _avaliacaoService.ObterTodos().Count());
            var avaliacao = _avaliacaoService.Obter(4);

            Assert.AreEqual("Boa", avaliacao.Descricao);
        }

        [TestMethod()]
        public void InserirEmojeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObterTest()
        {
            var avaliacao = _avaliacaoService.Obter(1);
            Assert.IsNotNull(avaliacao);
            Assert.AreEqual("Media", avaliacao.Descricao);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaAvaliacao = _avaliacaoService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaAvaliacao, typeof(IEnumerable<Avaliacao>));
            Assert.IsNotNull(listaAvaliacao);
            Assert.AreEqual(4, listaAvaliacao.Count());
            Assert.AreEqual(1, listaAvaliacao.First().IdAvaliacao);
            Assert.AreEqual("Media", listaAvaliacao.First().Descricao);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _avaliacaoService.Remover(2);
            // Assert
            Assert.AreEqual(2, _avaliacaoService.ObterTodos().Count());
            var avaliacao = _avaliacaoService.Obter(2);
            Assert.AreEqual(null, avaliacao);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var avaliacao = _avaliacaoService.Obter(3);
            avaliacao.Descricao = "Satisfatoria";

            _avaliacaoService.Editar(avaliacao);

            avaliacao = _avaliacaoService.Obter(3);
            Assert.AreEqual("Satisfatoria", avaliacao.Descricao);
        }
    }
}