using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecolhakiWeb.ViewModels;
using System.Collections.Generic;


namespace RecolhakiWeb.Controllers
{
    public class EmpresaController : Controller
    {
        IEmpresaService _empresaService;
        IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, IMapper mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }


        // GET: ManterController
        public ActionResult Index()
        {
            var listaAutores = _empresaService.ObterTodos();
            var listaAutoresModel = _mapper.Map<List<EmpresaViewModel>>(listaAutores);
            return View(listaAutoresModel);

        }

        // GET: ManterController/Details/5
        public ActionResult Details(int id)
        {
            Empresa empresa = _empresaService.Obter(id);
            EmpresaViewModel manterColetorModel = _mapper.Map<EmpresaViewModel>(empresa);
            return View(manterColetorModel);
        }

        // GET: ManterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel EmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Empresa>(EmpresaViewModel);
                _empresaService.Inserir(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Edit/5
        public ActionResult Edit(int id)
        {
            Empresa empresa = _empresaService.Obter(id);
            EmpresaViewModel EmpresaViewModel = _mapper.Map<EmpresaViewModel>(empresa);
            return View(EmpresaViewModel);
        }

        // POST: ManterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpresaViewModel EmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Empresa>(EmpresaViewModel);
                _empresaService.Editar(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Delete/5
        public ActionResult Delete(int id)
        {
            Empresa empresa = _empresaService.Obter(id);
            EmpresaViewModel EmpresaViewModel = _mapper.Map<EmpresaViewModel>(empresa);
            return View(EmpresaViewModel);
        }

        // POST: ManterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _empresaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
