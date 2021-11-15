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
    public class ColetorController : Controller
    {
        IColetorService _ColetorService;
        IMapper _mapper;

        public ColetorController(IColetorService coletorService, IMapper mapper)
        {
            _ColetorService = coletorService;
            _mapper = mapper;
        }



        // GET: ManterController
        public ActionResult Index()
        {
            var listaAutores = _ColetorService.ObterTodos();
            var listaAutoresModel = _mapper.Map<List<ColetorViewModel>>(listaAutores);
            return View(listaAutoresModel);
          
        }

        // GET: ManterController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _ColetorService.Obter(id);
            ColetorViewModel manterColetorModel = _mapper.Map<ColetorViewModel>(pessoa);
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
        public ActionResult Create(ColetorViewModel coletorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(coletorViewModel);
                _ColetorService.Inserir(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _ColetorService.Obter(id);
            ColetorViewModel manterColetorViewModel = _mapper.Map<ColetorViewModel>(pessoa);
            return View(manterColetorViewModel);
        }

        // POST: ManterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ColetorViewModel coletorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(coletorViewModel);
                _ColetorService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _ColetorService.Obter(id);
            ColetorViewModel manterColetorViewModel = _mapper.Map<ColetorViewModel>(pessoa);
            return View(manterColetorViewModel);
        }

        // POST: ManterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ColetorViewModel coletorViewModel)
        {
            _ColetorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
