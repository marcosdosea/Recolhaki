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
    public class NotificarProblemaController : Controller
    {
        INotificarProblemaService _notificarProblemaService;
        IMapper _mapper;

        public NotificarProblemaController(INotificarProblemaService notificarProblemaService, IMapper mapper)
        {
            _notificarProblemaService = notificarProblemaService;
            _mapper = mapper;
        }
        // GET: NotificarProblemaController
        public ActionResult Index()
        {
            var listaNotificacao = _notificarProblemaService.ObterTodos();
            var listaNotoficacaoModel = _mapper.Map<List<NotificarProblemaViewModel>>(listaNotificacao);
            return View(listaNotoficacaoModel);
        }

        // GET: NotificarProblemaController/Details/5
        public ActionResult Details(int id)
        {
            Notificacao notificarproblema = _notificarProblemaService.Obter(id);
            NotificarProblemaViewModel notificarProblemaModel = _mapper.Map<NotificarProblemaViewModel>(notificarproblema);
            return View(notificarProblemaModel);
        }

        // GET: NotificarProblemaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificarProblemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotificarProblemaViewModel notificarProblemaViewModel)
        {
            if (ModelState.IsValid)
            {
                var notificacao = _mapper.Map<Notificacao>(notificarProblemaViewModel);
                _notificarProblemaService.Inserir(notificacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: NotificarProblemaController/Edit/5
        public ActionResult Edit(int id)
        {
            Notificacao notificarproblema = _notificarProblemaService.Obter(id);
            NotificarProblemaViewModel notificarProblemaViewModel = _mapper.Map<NotificarProblemaViewModel>(notificarproblema);
            return View(notificarProblemaViewModel);
        }

        // POST: NotificarProblemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NotificarProblemaViewModel notificarProblemaViewModel)
        {
            if (ModelState.IsValid)
            {
                var notificacao = _mapper.Map<Notificacao>(notificarProblemaViewModel);
                _notificarProblemaService.Inserir(notificacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: NotificarProblemaController/Delete/5
        public ActionResult Delete(int id)
        {
            Notificacao notificacao = _notificarProblemaService.Obter(id);
            NotificarProblemaViewModel notificarProblemaViewModel = _mapper.Map<NotificarProblemaViewModel>(notificacao);
            return View(notificarProblemaViewModel);
        }

        // POST: NotificarProblemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _notificarProblemaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
