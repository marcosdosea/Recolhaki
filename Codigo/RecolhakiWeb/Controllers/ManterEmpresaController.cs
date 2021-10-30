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
    public class ManterEmpresaController : Controller
    {

        IManterEmpresaService _manterEmpresaService;
        IMapper _mapper;

        public ManterEmpresaController(IManterEmpresaService manterEmpresaService, IMapper mapper)
        {
            _manterEmpresaService = manterEmpresaService;
            _mapper = mapper;
        }


        // GET: ManterEmpresaController
        public ActionResult Index()
        {
            var listaEmpresas = _manterEmpresaService.ObterTodos();
            var listaEmpresasModel = _mapper.Map<List<ManterEmpresaViewModel>>(listaEmpresas);
            return View(listaEmpresasModel);
        }

        // GET: ManterEmpresaController/Details/5
        public ActionResult Details(int id)
        {
            Empresa Empresa = _manterEmpresaService.Obter(id);
            ManterEmpresaViewModel manterEmpresaModel = _mapper.Map<ManterEmpresaViewModel>(Empresa);
            return View(manterEmpresaModel);
        }

        // GET: ManterEmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManterEmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManterEmpresaViewModel manterEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var Empresa = _mapper.Map<Empresa>(manterEmpresaViewModel);
                _manterEmpresaService.Inserir(Empresa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterEmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            Empresa Empresa = _manterEmpresaService.Obter(id);
            ManterEmpresaViewModel manterEmpresaViewModel = _mapper.Map<ManterEmpresaViewModel>(Empresa);
            return View(manterEmpresaViewModel);
        }

        // POST: ManterEmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManterEmpresaViewModel manterEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Empresa>(manterEmpresaViewModel);
                _manterEmpresaService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterEmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            Empresa Empresa = _manterEmpresaService.Obter(id);
            ManterEmpresaViewModel manterEmpresaViewModel = _mapper.Map<ManterEmpresaViewModel>(Empresa);
            return View(manterEmpresaViewModel);
        }

        // POST: ManterEmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _manterEmpresaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
