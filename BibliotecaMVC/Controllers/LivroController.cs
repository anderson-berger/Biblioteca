using BibliotecaMVC.Models.Contracts.Services;
using BibliotecaMVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                return View(_livroService.Listar());
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome, Autor, Editora")]LivroDto livro)
        {
            try
            {
                _livroService.Cadastrar(livro);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public IActionResult Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorID(id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID, Nome, Autor, Editora")]LivroDto livro)
        {
            if (string.IsNullOrEmpty(livro.ID))
            {
                return NotFound();
            }

            try
            {
                _livroService.Atualizar(livro);
                return RedirectToAction("List");
            }catch(Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public IActionResult Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorID(id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorID(id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("ID, Nome, Autor, Editora")] LivroDto livro)
        {
            if (string.IsNullOrEmpty(livro.ID))
            {
                return NotFound();
            }

            try
            {
                _livroService.Excluir(livro.ID);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }


    }
}
