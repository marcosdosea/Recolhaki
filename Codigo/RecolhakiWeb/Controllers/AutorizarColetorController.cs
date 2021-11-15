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
    public class AutorizarColetorController : Controller
    {
        IAutorizarColetorService _AutorizarColetorService;
        IMapper _mapper;

        public AutorizarColetorController(IAutorizarColetorService autorizarColetorService, IMapper mapper)
        {
            _AutorizarColetorService = autorizarColetorService;
            _mapper = mapper;
        }


        // GET: AutorizarColetorController
        public ActionResult Index()
        {
            var listaColetores = _AutorizarColetorService.ObterTodos();
            var listaColetoresModel = _mapper.Map<List<AutorizarColetorViewModel>>(listaColetores);
            return View(listaColetoresModel);
        }

        // GET: AutorizarColetorController/Details/5
        public ActionResult Details(int id)
        {
            Autorizacaocoletor autorizarColetor = _AutorizarColetorService.Obter(id);
            AutorizarColetorViewModel autorizarColetorViewModel = _mapper.Map<AutorizarColetorViewModel>(autorizarColetor);
            return View(autorizarColetorViewModel);
        }

        // GET: AutorizarColetorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorizarColetorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorizarColetorViewModel autorizarColetorViewModel)
        {
            if (ModelState.IsValid)
            {
                var coletor = _mapper.Map<Autorizacaocoletor>(autorizarColetorViewModel);
                _AutorizarColetorService.Inserir(coletor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AutorizarColetorController/Edit/5
        public ActionResult Edit(int id)
        {
            Autorizacaocoletor coletor = _AutorizarColetorService.Obter(id);
            AutorizarColetorViewModel autorizarColetorViewModel = _mapper.Map<AutorizarColetorViewModel>(coletor);
            return View(autorizarColetorViewModel);
        }

        // POST: AutorizarColetorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutorizarColetorViewModel autorizarColetorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Autorizacaocoletor>(autorizarColetorViewModel);
                _AutorizarColetorService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AutorizarColetorController/Delete/5
        public ActionResult Delete(int id, Autorizacaocoletor autorizacaocoletor)
        {
            Autorizacaocoletor coletor = _AutorizarColetorService.Obter(id);
            AutorizarColetorViewModel autorizarColetorViewModel = _mapper.Map<AutorizarColetorViewModel>(coletor);
            return View(autorizarColetorViewModel);
        }

        // POST: AutorizarColetorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _AutorizarColetorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
