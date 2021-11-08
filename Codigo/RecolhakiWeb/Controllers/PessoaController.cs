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
    public class PessoaController : Controller
    {

        IPessoaService _PessoaService;
        IMapper _mapper;

        public PessoaController(IPessoaService PessoaService, IMapper mapper)
        {
            _PessoaService = PessoaService;
            _mapper = mapper;
        }


        // GET: PessoaController
        public ActionResult Index()
        {
            var listaPessoas = _PessoaService.ObterTodos();
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _PessoaService.Obter(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel PessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(PessoaViewModel);
                _PessoaService.Inserir(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _PessoaService.Obter(id);
            PessoaViewModel PessoaViewModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(PessoaViewModel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaViewModel PessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(PessoaViewModel);
                _PessoaService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _PessoaService.Obter(id);
            PessoaViewModel PessoaViewModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(PessoaViewModel);
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _PessoaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
