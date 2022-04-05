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

        private static EmpresaControllerTests controller;

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
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void EmpresaControllerTest()
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
            Assert.AreEqual("BGS", empresaModel.Nome);
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
        public void CreateTest_Valido()
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
        public void EditTest_Invalido()
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
            Assert.AreEqual("BGS", empresaModel.Nome);
            Assert.AreEqual(64019700, empresaModel.Cep);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetEmpresaModels().IdEmpresa, GetTargetEmpresaModels());

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

            var result = controller.Delete(GetTargetEmpresaModels().IdPessoa, GetTargetEmpresaModels());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModels));
            EmpresaViewModels empresaModel = (EmpresaViewModels)viewResult.ViewData.Model;
            Assert.AreEqual("BGS", empresaModel.Nome);
            Assert.AreEqual(64019700, empresaModel.Cep);
        }
    }
}