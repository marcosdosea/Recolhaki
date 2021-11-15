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
    public class AutorizarColetorServiceTests
    {
        private recolhakiContext _context;
        private IAutorizarColetorService _AutorizarColetorService;

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
            var autorizarcoletor = new List<Autorizacaocoletor>
                {
                    new Autorizacaocoletor { ColetorIdColetor = 1, StatusAutorizacao = "Não"},
                    new Autorizacaocoletor { ColetorIdColetor = 2, StatusAutorizacao = "Não"},
                    new Autorizacaocoletor { ColetorIdColetor = 3, StatusAutorizacao = "Sim"},
                };

            _context.AddRange(autorizarcoletor);
            _context.SaveChanges();

            _AutorizarColetorService = new AutorizarColetorService(_context);
        }

        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _AutorizarColetorService.Inserir(new Autorizacaocoletor() { ColetorIdColetor = 4, StatusAutorizacao = "Sim" });
            // Assert
            Assert.AreEqual(4, _AutorizarColetorService.ObterTodos().Count());
            var autorizacaocoletor = _AutorizarColetorService.Obter(4);
            Assert.AreEqual("sim", autorizacaocoletor.StatusAutorizacao);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var autorizacaocoletor = _AutorizarColetorService.Obter(3);
            autorizacaocoletor.StatusAutorizacao = "sim";

            _AutorizarColetorService.Editar(autorizacaocoletor);
            autorizacaocoletor = _AutorizarColetorService.Obter(3);
            Assert.AreEqual("sim", autorizacaocoletor.StatusAutorizacao);

        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _AutorizarColetorService.Remover(2);
            // Assert
            Assert.AreEqual(2, _AutorizarColetorService.ObterTodos().Count());
            var autorizacaocoletor = _AutorizarColetorService.Obter(2);
            Assert.AreEqual(2, autorizacaocoletor);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaautorizacaocoletor = _AutorizarColetorService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaautorizacaocoletor, typeof(IEnumerable<Autorizacaocoletor>));
            Assert.IsNotNull(listaautorizacaocoletor);
            Assert.AreEqual(3, listaautorizacaocoletor.Count());
            Assert.AreEqual(1, listaautorizacaocoletor.First().ColetorIdColetor);
            Assert.AreEqual("Não", listaautorizacaocoletor.First().StatusAutorizacao);
        }


        [TestMethod()]
        public void ObterTest()
        {
            var autorizacaocoletor = _AutorizarColetorService.Obter(1);
            Assert.IsNotNull(autorizacaocoletor);
            Assert.AreEqual("Sim", autorizacaocoletor.StatusAutorizacao);
        }

        

    } 
}