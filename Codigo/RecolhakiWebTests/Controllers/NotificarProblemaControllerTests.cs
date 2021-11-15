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
    public class NotificarProblemaControllerTests
    {

        private static NotificarProblemaController controller;

        [ClassInitialize]
        public static void Initialize()
        {
            // Arrange
            var mockService = new Mock<INotificarProblemaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new NotificarProblemaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestNotificarProblema());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetNotificacao());
            mockService.Setup(service => service.Editar(It.IsAny<Notificacao>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Notificacao>()))
                .Verifiable();
            controller = new NotificarProblemaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<NotificarProblemaViewModel>));
            List<NotificarProblemaViewModel> lista = (List<NotificarProblemaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NotificarProblemaViewModel));
            NotificarProblemaViewModel NotificarProblemaViewModel = (NotificarProblemaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("José Nunes", NotificarProblemaViewModel.Nome);
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
            var result = controller.Create(GetNewNotifocacao());

            // Assert
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NotificarProblemaViewModel));
            NotificarProblemaViewModel NotificarProblemaViewModel = (NotificarProblemaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", NotificarProblemaViewModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NotificarProblemaViewModel));
            NotificarProblemaViewModel NotificarProblemaViewModel = (NotificarProblemaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("José Nunes", NotificarProblemaViewModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetNotificarProblemaModel().IdPessoa, GetTargetNotificarProblemaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private NotificarProblemaViewModel GetNewNotifocacao()
        {
            return new NotificarProblemaViewModel
            {
                IdPessoa = 4,
                Nome = "José Nunes",
            };
        }

        private static Notificacao GetTargetNotificacao()
        {
            return new Notificacao
            {
                IdPessoa = 1,
                Nome = "Antonio Nunes",
            };
        }

        private object GetTargetNotificarProblemaModel()
        {
            return new NotificarProblemaViewModel
            {
                IdPessoa = 2,
                Nome = "Machado de Assis",
            };
        }

        private static IEnumerable<Notificacao> GetTestNotificarProblema()
        {
            return new List<Notificacao>
            {
                new Notificacao
                {
                    IdPessoa = 1,
                    Nome = "Antonio Nunes",
                },
                new Notificacao
                {
                    IdPessoa = 2,
                    Nome = "Machado de Assis",
                },
                new Notificacao
                {
                    IdPessoa = 3,
                    Nome = "Marcos Dósea",
                },
            };
        }

    }
}