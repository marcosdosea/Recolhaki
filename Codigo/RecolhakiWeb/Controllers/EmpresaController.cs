using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecolhakiWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.Controllers
{
    public class EmpresaController : Controller
    {
        IEmpresaService _EmpresaService;
        IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, IMapper mapper)
        {
            _EmpresaService = empresaService;
            _mapper = mapper;
        }
        // GET: EmpresaController
        public ActionResult Index()
        {
            var listaAutores = _EmpresaService.ObterTodos();
            var listaAutoresModel = _mapper.Map<List<EmpresaViewModel>>(listaAutores);
            return View(listaAutoresModel);
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _EmpresaService.Obter(id);
            EmpresaViewModel empresaModel = _mapper.Map<EmpresaViewModel>(pessoa);
            return View(empresaModel);
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Pessoa>(empresaViewModel);
                _EmpresaService.Inserir(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _EmpresaService.Obter(id);
            EmpresaViewModel empresaViewModel = _mapper.Map<EmpresaViewModel>(pessoa);
            return View(empresaViewModel);
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpresaViewModel empresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var empresa = _mapper.Map<Pessoa>(empresaViewModel);
                _EmpresaService.Editar(empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _EmpresaService.Obter(id);
            EmpresaViewModel empresaViewModel = _mapper.Map<EmpresaViewModel>(pessoa);
            return View(empresaViewModel);
        }

        // POST: EmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _EmpresaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
