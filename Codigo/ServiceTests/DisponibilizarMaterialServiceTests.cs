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
    public class DisponibilizarMaterialServiceTests
    {
        private recolhakiContext _context;
        private IDisponibilizarMaterialService _DisponibilizarMaterialService;


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

            _DisponibilizarMaterialService = new DisponibilizarMaterialService(_context);
        }

        [TestMethod()]
        public void DisponibilizarMaterialServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getMaterialTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InserirTest()
        {
            Assert.Fail();
        }

        public void ObterPorNomeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoverTest()
        {
            Assert.Fail();
        }
    }
}