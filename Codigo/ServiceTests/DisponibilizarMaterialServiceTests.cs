using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass()]
    public class DisponibilizarMaterialServiceTests
    {
        private recolhakiContext _context;
        private IDisponibilizarMaterialService _disponibilizarMaterialService;


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
            var doacaomaterialreciclavel = new List<Doacaomaterialreciclavel>
                {
                    new Doacaomaterialreciclavel { IdDoacaoMaterialReciclavel = 1, Nome = "Plastico"},
                    new Doacaomaterialreciclavel { IdDoacaoMaterialReciclavel = 2, Nome = "Papel"},
                    new Doacaomaterialreciclavel { IdDoacaoMaterialReciclavel = 3, Nome = "Vidro"},
                };

            _context.AddRange(doacaomaterialreciclavel);
            _context.SaveChanges();

            _disponibilizarMaterialService = new DisponibilizarMaterialService(_context);
        }

        [TestMethod()]
        public void DisponibilizarMaterialServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditarTest()
        {
            var doacaomaterialreciclavel = _disponibilizarMaterialService.Obter(3);
            doacaomaterialreciclavel.Nome = "Vidro";

            _disponibilizarMaterialService.Editar(doacaomaterialreciclavel);
            doacaomaterialreciclavel = _disponibilizarMaterialService.Obter(3);
            Assert.AreEqual("Vidro", doacaomaterialreciclavel.Nome);

        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _disponibilizarMaterialService.Inserir(new Doacaomaterialreciclavel() { IdDoacaoMaterialReciclavel = 4, Nome = "Vidro" });
            // Assert
            Assert.AreEqual(4, _disponibilizarMaterialService.ObterTodos().Count());
            var doacaomaterialreciclavel = _disponibilizarMaterialService.Obter(4);
            Assert.AreEqual("Vidro", doacaomaterialreciclavel.Nome);
        }

        public void ObterPorNomeTest()
        {
            var doacaomaterialreciclavel = _disponibilizarMaterialService.ObterPorNome("Plastico");
            Assert.IsNotNull(doacaomaterialreciclavel);
            Assert.AreEqual(1, doacaomaterialreciclavel.Count());
            Assert.AreEqual("Plastico", doacaomaterialreciclavel.First().Nome);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaDoacao = _disponibilizarMaterialService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaDoacao, typeof(IEnumerable<Doacaomaterialreciclavel>));
            Assert.IsNotNull(listaDoacao);
            Assert.AreEqual(4, listaDoacao.Count());
            Assert.AreEqual(1, listaDoacao.First().IdDoacaoMaterialReciclavel);
            Assert.AreEqual("Plastico", listaDoacao.First().Nome);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _disponibilizarMaterialService.Remover(2);
            // Assert
            Assert.AreEqual(2, _disponibilizarMaterialService.ObterTodos().Count());
            var pessoa = _disponibilizarMaterialService.Obter(2);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var doacaomaterialreciclavel = _disponibilizarMaterialService.Obter(1);
            Assert.IsNotNull(doacaomaterialreciclavel);
            Assert.AreEqual("Plastico", doacaomaterialreciclavel.Nome);
        }
    }
}