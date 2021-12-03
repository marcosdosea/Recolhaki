using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecolhakiWeb.ViewModels;
using System.Collections.Generic;

namespace RecolhakiWeb.Controllers
{
    public class MaterialreciclavelController : Controller
    {

        IMaterialreciclavelService _materialreciclavelService;
        IMapper _mapper;

        public MaterialreciclavelController(IMaterialreciclavelService materialreciclavel, IMapper mapper)
        {
            _materialreciclavelService = materialreciclavel;
            _mapper = mapper;
        }

        // GET: MaterialreciclavelController
        public ActionResult Index()
        {
            var listaMaterialreciclavel = _materialreciclavelService.ObterTodos();
            var listaMaterialreciclaveModel = _mapper.Map<List<MaterialreciclavelViewModel>>(listaMaterialreciclavel);
            return View(listaMaterialreciclaveModel);
        }

        // GET: MaterialreciclavelController/Details/5
        public ActionResult Details(int id)
        {
            Materialreciclavel materialreciclavel = _materialreciclavelService.Obter(id);
            MaterialreciclavelViewModel materialreciclavelModel = _mapper.Map<MaterialreciclavelViewModel>(materialreciclavel);
            return View(materialreciclavelModel);
        }

        // GET: MaterialreciclavelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialreciclavelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaterialreciclavelViewModel materialreciclavelViewModel)
        {
            if (ModelState.IsValid)
            {
                var materialreciclavel = _mapper.Map<Materialreciclavel>(materialreciclavelViewModel);
                _materialreciclavelService.Inserir(materialreciclavel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MaterialreciclavelController/Edit/5
        public ActionResult Edit(int id)
        {
            Materialreciclavel materialreciclavel = _materialreciclavelService.Obter(id);
            MaterialreciclavelViewModel materialreciclavelViewModel = _mapper.Map<MaterialreciclavelViewModel>(materialreciclavel);
            return View(materialreciclavelViewModel);
        }

        // POST: MaterialreciclavelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaterialreciclavelViewModel materialreciclavelViewModel)
        {
            if (ModelState.IsValid)
            {
                var materialreciclavel = _mapper.Map<Materialreciclavel>(materialreciclavelViewModel);
                _materialreciclavelService.Editar(materialreciclavel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MaterialreciclavelController/Delete/5
        public ActionResult Delete(int id)
        {
            Materialreciclavel materialreciclavel = _materialreciclavelService.Obter(id);
            MaterialreciclavelViewModel materialreciclavelViewModel = _mapper.Map<MaterialreciclavelViewModel>(materialreciclavel);
            return View(materialreciclavelViewModel);
        }

        // POST: MaterialreciclavelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _materialreciclavelService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
