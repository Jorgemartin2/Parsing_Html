using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Emprestimo_Livros.Interface;
using Emprestimo_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Emprestimo_Livros.Controllers
{
    public class LivroController : Controller
    {
        private readonly IRepositoryLivro _repositoryLivro;
        public LivroController(IRepositoryLivro repositoryLivro)
        {
            _repositoryLivro = repositoryLivro;
        }
        public IActionResult Index()
        {
            List<Livro> livros = _repositoryLivro.BuscarLivros();
            return View(livros);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criarlivro(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryLivro.Adicionar(livro);
                    TempData["MensagemSucesso"] = "Livro adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Index", livro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar o livro. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            Livro livro = _repositoryLivro.BuscarPorId(id);
            if (livro == null)
            {
                return View();
            }
            return View(livro);
        }
        [HttpPost]
        public IActionResult Alterar(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryLivro.Atualizar(livro);
                    TempData["MensagemSucesso"] = "Livro alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao alterar o livro. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Livro livro = _repositoryLivro.BuscarPorId(id);
            return View(livro);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _repositoryLivro.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir o livro";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao excluir o livro. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}