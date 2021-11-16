using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecolhakiWeb.Mappers;
using RecolhakiWeb.ViewModels;
using System.Collections.Generic;

namespace RecolhakiWeb.Controllers.Tests
{
    [TestClass()]
    public class AvaliacaoControllerTests
    {

        private static AvaliacaoController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IAvaliacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AvaliacaoProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestAvaliacao());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetAvaliacao());
            mockService.Setup(service => service.Editar(It.IsAny<Avaliacao>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Avaliacao>()))
                .Verifiable();
            controller = new AvaliacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AvaliacaoViewModel>));
            List<AvaliacaoViewModel> lista = (List<AvaliacaoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel avaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            
            Assert.AreEqual("1", avaliacaoViewModel.IdEmoje);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAvaliacao());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel avaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("2", avaliacaoViewModel.IdEmoje);

        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel avaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("1", avaliacaoViewModel.IdEmoje);

        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAvaliacao().IdAvaliacao, GetTargetAvaliacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static AvaliacaoViewModel GetNewAvaliacao()
        {
            return new AvaliacaoViewModel
            {
                IdAvaliacao = 1,
                IdEmoje = 2,
            };
        }

        private static Avaliacao GetTargetAvaliacao()
        {
            return new Avaliacao
            {
                IdAvaliacao = 1,
                IdEmoje = 3,
            };
        }

        private static Avaliacao GetTargetAvaliacaoModel()
        {
            return new Avaliacao
            {
                IdAvaliacao = 1,
                IdEmoje = 3,
            };
        }

        private static IEnumerable<Avaliacao> GetTestAvaliacao()
        {
            return new List<Avaliacao>
            {
                new Avaliacao
                {
                    IdAvaliacao = 1,
                    IdEmoje = 3,
                },
                new Avaliacao
                {
                    IdAvaliacao = 2,
                    IdEmoje = 4,
                },
                new Avaliacao
                {
                    IdAvaliacao = 3,
                    IdEmoje = 5,
                },
            };
        }
    }
}