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
    public class EmpresaControllerTests
    {
        private static EmpresaController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IEmpresaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new EmpresaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestEmpresa());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetEmpresa());
            mockService.Setup(service => service.Editar(It.IsAny<Empresa>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Empresa>()))
                .Verifiable();
            controller = new EmpresaController(mockService.Object, mapper);
        }


        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<EmpresaViewModels>));
            List<EmpresaViewModels> lista = (List<EmpresaViewModels>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModels));
            EmpresaViewModels empresaModel = (EmpresaViewModels)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", empresaModel.Nome);
            Assert.AreEqual(64019700, empresaModel.Cep);
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
            var result = controller.Create(GetNewEmpresa());

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
            var result = controller.Create(GetNewEmpresa());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModels));
            EmpresaViewModels empresaModel = (EmpresaViewModels)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", empresaModel.Nome);
            Assert.AreEqual(64019700, empresaModel.Cep);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetEmpresaModel().IdEmpresa, GetTargetEmpresaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act

            var result = controller.Delete(GetTargetEmpresaModel().IdEmpresa, GetTargetEmpresaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModels));
            EmpresaViewModels empresaModel = (EmpresaViewModels)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", empresaModel.Nome);
            Assert.AreEqual(64019700, empresaModel.Cep);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetEmpresaModel().IdEmpresa, GetTargetEmpresaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static EmpresaViewModels GetNewEmpresa()
        {
            return new EmpresaViewModels
            {
                IdEmpresa = 4,
                Nome = "Ian Sommerville",
                Cep = 69316002
            };

        }
        private static Empresa GetTargetEmpresa()
        {
            return new Empresa
            {
                IdEmpresa = 1,
                Nome = "Machado de Assis",
                Cep = 64019700
            };
        }

        private static EmpresaViewModels GetTargetEmpresaModel()
        {
            return new EmpresaViewModels
            {
                IdEmpresa = 2,
                Nome = "Machado de Assis",
                Cep = 64019700
            };
        }

        private static IEnumerable<Empresa> GetTestEmpresa()
        {
            return new List<Empresa>
            {
                new Empresa
                {
                    IdEmpresa = 1,
                    Nome = "Graciliano Ramos",
                    Cep = 49530000
                },
                new Empresa
                {
                    IdEmpresa = 2,
                    Nome = "Machado de Assis",
                    Cep = 64019700
                },
                new Empresa
                {
                    IdEmpresa = 3,
                    Nome = "Marcos Dósea",
                    Cep = 49041-140
                },
            };
        }

    }
}