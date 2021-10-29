using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecolhakiWeb.ViewModels;
using System.Collections.Generic;

namespace RecolhakiWeb.Controllers
{
    public class DisponibilizarMaterialController : Controller
    {

        IDisponibilizarMaterialService _disponibilizarMaterialService;
        IMapper _mapper;

        public DisponibilizarMaterialController(IDisponibilizarMaterialService disponibilizarMaterialService, IMapper mapper)
        {
            _disponibilizarMaterialService = disponibilizarMaterialService;
            _mapper = mapper;
        }

        // GET: DisponibilizarMaterialController
        public ActionResult Index()
        {
            var listaMaterial = _disponibilizarMaterialService.ObterTodos();
            var listaMaterialModel = _mapper.Map<List<DisponibilizarMaterialViewModel>>(listaMaterial);
            return View(listaMaterialModel);
        }

        // GET: DisponibilizarMaterialController/Details/5
        public ActionResult Details(int id)
        {
            Doacaomaterialreciclavel doacaomaterialreciclavel = _disponibilizarMaterialService.getMaterial(id);
            DisponibilizarMaterialViewModel disponibilizarMaterialModel = _mapper.Map<DisponibilizarMaterialViewModel>(doacaomaterialreciclavel);
            return View(disponibilizarMaterialModel);
        }

        // GET: DisponibilizarMaterialController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisponibilizarMaterialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisponibilizarMaterialViewModel disponibilizarMaterialViewModel)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Doacaomaterialreciclavel>(disponibilizarMaterialViewModel);
                _disponibilizarMaterialService.Inserir(material);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DisponibilizarMaterialController/Edit/5
        public ActionResult Edit(int id)
        {
            Doacaomaterialreciclavel doacaomaterialreciclavel = _disponibilizarMaterialService.getMaterial(id);
            DisponibilizarMaterialViewModel manterColetorViewModel = _mapper.Map<DisponibilizarMaterialViewModel>(doacaomaterialreciclavel);
            return View(manterColetorViewModel);
        }

        // POST: DisponibilizarMaterialController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisponibilizarMaterialViewModel disponibilizarMaterialViewModel)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Doacaomaterialreciclavel>(disponibilizarMaterialViewModel);
                _disponibilizarMaterialService.Inserir(material);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DisponibilizarMaterialController/Delete/5
        public ActionResult Delete(int id)
        {
            Doacaomaterialreciclavel doacaomaterialreciclavel = _disponibilizarMaterialService.getMaterial(id);
            DisponibilizarMaterialViewModel manterColetorViewModel = _mapper.Map<DisponibilizarMaterialViewModel>(doacaomaterialreciclavel);
            return View(manterColetorViewModel);
        }

        // POST: DisponibilizarMaterialController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _disponibilizarMaterialService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
