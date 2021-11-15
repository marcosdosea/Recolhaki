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
    public class AutorizarColetorControllerTests
    {
        private static AutorizarColetorController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IAutorizarColetorService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AutorizarColetorProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestAutorizarColetor());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetAutorizarColetor());
            mockService.Setup(service => service.Editar(It.IsAny<Autorizacaocoletor>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Autorizacaocoletor>()))
                .Verifiable();
            controller = new AutorizarColetorController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AutorizarColetorViewModel>));
            List<AutorizarColetorViewModel> lista = (List<AutorizarColetorViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorizarColetorViewModel));
            AutorizarColetorViewModel AutorizarColetorViewModel = (AutorizarColetorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", AutorizarColetorViewModel.StatusAutorizacao);

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
            var result = controller.Create(GetNewPessoa());

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
            controller.ModelState.AddModelError("StatusAutorizacao", "Campo requerido");

            // Act
            var result = controller.Create(GetNewPessoa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorizarColetorViewModel));
            AutorizarColetorViewModel AutorizarColetorViewModel = (AutorizarColetorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Não", AutorizarColetorViewModel.StatusAutorizacao);

        }

       
        

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAutorizarColetorModel().ColetorIdColetor, GetTargetAutorizarColetorModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static AutorizarColetorViewModel GetNewPessoa()
        {
            return new AutorizarColetorViewModel
            {
               ColetorIdColetor = 4,
                StatusAutorizacao = "Sim"
            };

        }
        private static Autorizacaocoletor GetTargetAutorizarColetor()
        {
            return new Autorizacaocoletor
            {
               ColetorIdColetor = 3,
                StatusAutorizacao = "Sim"
            };
        }

        private static Autorizacaocoletor GetTargetAutorizarColetorModel()
        {
            return new Autorizacaocoletor
            {
               ColetorIdColetor = 5,
                StatusAutorizacao = "Não"
            };
        }

        private static IEnumerable<Autorizacaocoletor> GetTestAutorizarColetor()
        {
            return new List<Autorizacaocoletor>
            {
                new Autorizacaocoletor
                {
                   ColetorIdColetor = 1,
                    StatusAutorizacao = "Não",
                },
                new Autorizacaocoletor
                {
                   ColetorIdColetor = 2,
                    StatusAutorizacao = "Não"
                },
                new Autorizacaocoletor
                {
                  ColetorIdColetor = 3,
                    StatusAutorizacao = "sim"
                },
            };
        }

    }
}