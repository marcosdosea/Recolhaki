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
    public class PessoaControllerTests
    {

        private static PessoaController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestPessoas());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Editar(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaViewModel>));
            List<PessoaViewModel> lista = (List<PessoaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel PessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", PessoaViewModel.Nome);
            
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
            controller.ModelState.AddModelError("Nome", "Campo requerido");

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel PessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", PessoaViewModel.Nome);
           
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel PessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", PessoaViewModel.Nome);
            
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaModel().IdAutor, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static PessoaViewModel GetNewPessoa()
        {
            return new PessoaViewModel
            {
                IdPessoa = 4,
                Nome = "Ian Sommerville",
            };

        }
        private static Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                IdPessoa = 1,
                Nome = "Machado de Assis",
            };
        }

        private static PessoaViewModel GetTargetPessoaModel()
        {
            return new PessoaViewModel
            {
                IdPessoa = 2,
                Nome = "Machado de Assis",
            };
        }

        private static IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    IdPessoa = 1,
                    Nome = "Graciliano Ramos",
                },
                new Pessoa
                {
                    IdPessoa = 2,
                    Nome = "Machado de Assis", 
                },
                new Pessoa
                {
                    IdPessoa = 3,
                    Nome = "Marcos Dósea",
                },
            };
        }
    }
}