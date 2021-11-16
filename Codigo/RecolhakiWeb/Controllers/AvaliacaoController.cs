using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecolhakiWeb.ViewModels;
using System.Collections.Generic;

namespace RecolhakiWeb.Controllers
{
    public class AvaliacaoController : Controller
    {
        IAvaliacaoService _avaliacaoService;
        IMapper _mapper;

        public AvaliacaoController (IAvaliacaoService avaliacaoService, IMapper mapper)
        {
            _avaliacaoService = avaliacaoService;
            _mapper = mapper;
        }

        // GET: AvaliacaoController
        public ActionResult Index()
        {
            var listaAvaliacao = _avaliacaoService.ObterTodos();
            var listaAvaliacaoModel = _mapper.Map<List<AvaliacaoViewModel>>(listaAvaliacao);
            return View(listaAvaliacaoModel);
        }

        // GET: AvaliacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvaliacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel avaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoViewModel);
                _avaliacaoService.Inserir(avaliacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AvaliacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Obter(id);
            AvaliacaoViewModel avaliacaoViewModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);
            return View(avaliacaoViewModel);
        }

        // POST: AvaliacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AvaliacaoViewModel avaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoViewModel);
                _avaliacaoService.Editar(avaliacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AvaliacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Obter(id);
            AvaliacaoViewModel avaliacaoViewModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);
            return View(avaliacaoViewModel);
        }

        // POST: AvaliacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvaliacaoViewModel avaliacaoViewModel)
        {
            _avaliacaoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
