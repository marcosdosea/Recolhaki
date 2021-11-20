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
    public class ManterPessoaController : Controller
    {

        IManterPessoaService _manterPessoaService;
        IMapper _mapper;

        public ManterPessoaController(IManterPessoaService manterPessoaService, IMapper mapper)
        {
            _manterPessoaService = manterPessoaService;
            _mapper = mapper;
        }


        // GET: ManterPessoaController
        public ActionResult Index()
        {
            var listaPessoas = _manterPessoaService.ObterTodos();
            var listaPessoasModel = _mapper.Map<List<ManterPessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        // GET: ManterPessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _manterPessoaService.Obter(id);
            ManterPessoaViewModel manterPessoaModel = _mapper.Map<ManterPessoaViewModel>(pessoa);
            return View(manterPessoaModel);
        }

        // GET: ManterPessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManterPessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManterPessoaViewModel manterPessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(manterPessoaViewModel);
                _manterPessoaService.Inserir(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterPessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _manterPessoaService.Obter(id);
            ManterPessoaViewModel manterPessoaViewModel = _mapper.Map<ManterPessoaViewModel>(pessoa);
            return View(manterPessoaViewModel);
        }

        // POST: ManterPessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManterPessoaViewModel manterPessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = _mapper.Map<Pessoa>(manterPessoaViewModel);
                _manterPessoaService.Editar(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ManterPessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _manterPessoaService.Obter(id);
            ManterPessoaViewModel manterPessoaViewModel = _mapper.Map<ManterPessoaViewModel>(pessoa);
            return View(manterPessoaViewModel);
        }

        // POST: ManterPessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _manterPessoaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
