using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecolhakiWeb.Controllers;
using RecolhakiWeb.Mappers;
using RecolhakiWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecolhakiWeb.Controllers.Tests
{
    [TestClass()]
    public class DisponibilizarMaterialControllerTests
    {

        private static DisponibilizarMaterialController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IDisponibilizarMaterialService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new DisponibilizarMaterialProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestMaterialReciclavel());
            mockService.Setup(service => service.getMaterial(1))
                .Returns(GetTargetMaterialReciclavel());
            mockService.Setup(service => service.Editar(It.IsAny<Doacaomaterialreciclavel>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Doacaomaterialreciclavel>()))
                .Verifiable();
            controller = new DisponibilizarMaterialController(mockService.Object, mapper);
        }


        [TestMethod()]
        public void DisponibilizarMaterialControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DisponibilizarMaterialViewModel>));
            List<DisponibilizarMaterialViewModel> lista = (List<DisponibilizarMaterialViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMaterialViewModel));
            DisponibilizarMaterialViewModel disponibilizarMaterialViewModel = (DisponibilizarMaterialViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Plastico", disponibilizarMaterialViewModel.Nome);
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
            var result = controller.Create(GetNewMaterialReciclavel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMaterialViewModel));
            DisponibilizarMaterialViewModel disponibilizarMaterialViewModel = (DisponibilizarMaterialViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Plastico", disponibilizarMaterialViewModel.Nome);

        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilizarMaterialViewModel));
            DisponibilizarMaterialViewModel disponibilizarMaterialViewModel = (DisponibilizarMaterialViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Plastico", disponibilizarMaterialViewModel.Nome);

        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetMaterialReciclavelModel().IdDoacaoMaterialReciclavel, GetTargetMaterialReciclavelModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static DisponibilizarMaterialViewModel GetNewMaterialReciclavel()
        {
            return new DisponibilizarMaterialViewModel
            {
                IdDoacaoMaterialReciclavel = 4,
                Nome = "Metal",
                Peso = 2.5F,
            };

        }

        private static Doacaomaterialreciclavel GetTargetMaterialReciclavel()
        {
            return new Doacaomaterialreciclavel
            {
                IdDoacaoMaterialReciclavel = 1,
                Nome = "Plastico",
                Peso = 2.5F,
            };
        }


        private static DisponibilizarMaterialViewModel GetTargetMaterialReciclavelModel()
        {
            return new DisponibilizarMaterialViewModel
            {
                IdDoacaoMaterialReciclavel = 2,
                Nome = "Plastico",
                Peso = 2.5F,
            };
        }

        private static IEnumerable<Doacaomaterialreciclavel> GetTestMaterialReciclavel()
        {
            return new List<Doacaomaterialreciclavel>
            {
                new Doacaomaterialreciclavel
                {
                    IdDoacaoMaterialReciclavel = 1,
                    Nome = "Plastico",
                    Peso = 2.5F,
                },
                new Doacaomaterialreciclavel
                {
                    IdDoacaoMaterialReciclavel = 2,
                    Nome = "Papel",
                    Peso = 2.3F,
                },
                new Doacaomaterialreciclavel
                {
                    IdDoacaoMaterialReciclavel = 3,
                    Nome = "Vidro",
                    Peso = 1.5F,
                },
            };
        }
    }
}