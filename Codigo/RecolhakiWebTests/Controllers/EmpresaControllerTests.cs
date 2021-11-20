using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecolhakiWeb.Controllers;
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
				.Returns(GetTestPessoa());
			mockService.Setup(service => service.Obter(3))
				.Returns(GetTargetPessoa());
			mockService.Setup(service => service.Editar(It.IsAny<Pessoa>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<EmpresaViewModel>));
			List<EmpresaViewModel> lista = (List<EmpresaViewModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(3);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModel));
			EmpresaViewModel EmpresaViewModel = (EmpresaViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Ayla Miller", EmpresaViewModel.Nome);

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
			var result = controller.Edit(3);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModel));
			EmpresaViewModel empresaViewModel = (EmpresaViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Ayla Miller", EmpresaViewModel.Nome);

		}



		[TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(3);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EmpresaViewModel));
			EmpresaViewModel empresaViewModel = (EmpresaViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Ayla Miller", empresaViewModel.Nome);

		}



		private static EmpresaViewModel GetNewPessoa()
		{
			return new EmpresaViewModel
			{
				IdPessoa = 6,
				Nome = "Graciliano Ramos",

			};

		}
		private static Pessoa GetTargetPessoa()
		{
			return new Pessoa
			{
				IdPessoa = 3,
				Nome = "Ayla Miller",

			};
		}

		private static EmpresaViewModel GetTargetPessoaViewModel()
		{
			return new EmpresaViewModel
			{
				IdPessoa = 3,
				Nome = "Ayla Miller",

			};
		}

		private static IEnumerable<Pessoa> GetTestPessoa()
		{
			return new List<Pessoa>
			{
				new Pessoa
				{
					IdPessoa = 3,
					Nome = "Ayla Miller",

				},
				new Pessoa
				{
					IdPessoa = 5,
					Nome = "teste",

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