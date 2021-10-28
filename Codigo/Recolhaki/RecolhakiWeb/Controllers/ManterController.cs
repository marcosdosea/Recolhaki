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
    public class ManterController : Controller
    {
        IManterColetorService _manterColetorService;
        IMapper _mapper;

        public ManterController(IManterColetorService manterColetorService, IMapper mapper)
        {
            _manterColetorService = manterColetorService;
            _mapper = mapper;
        }



        // GET: ManterController
        public ActionResult Index()
        {
            var listaAutores = _manterColetorService.ObterTodos();
            var listaAutoresModel = _mapper.Map<List<ManterColetorViewModel>>(listaAutores);
            return View(listaAutoresModel);
          
        }

        // GET: ManterController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _manterColetorService.Obter(id);
            ManterColetorViewModel manterColetorModel = _mapper.Map<ManterColetorViewModel>(pessoa);
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
        public ActionResult Create(ManterColetorViewModel manterColetorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(manterColetorViewModel);
                _manterColetorService.Inserir(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _manterColetorService.Obter(id);
            ManterColetorViewModel manterColetorViewModel = _mapper.Map<ManterColetorViewModel>(pessoa);
            return View(manterColetorViewModel);
        }

        // POST: ManterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManterColetorViewModel manterColetorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(manterColetorViewModel);
                _manterColetorService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _manterColetorService.Obter(id);
            ManterColetorViewModel manterColetorViewModel = _mapper.Map<ManterColetorViewModel>(pessoa);
            return View(manterColetorViewModel);
        }

        // POST: ManterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _manterColetorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
