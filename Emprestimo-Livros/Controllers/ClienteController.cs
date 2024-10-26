using System;
using Microsoft.AspNetCore.Mvc;
using Emprestimo_Livros.Models;
using Emprestimo_Livros.Interface;

namespace Emprestimo_Livros.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente _repositoryCliente;
        public ClienteController(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }
        public IActionResult Index()
        {
            List<Cliente> clientes = _repositoryCliente.BuscarClientes();
            return View(clientes);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCliente.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Adicionar", cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao adicionar o cliente. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            Cliente clientes = _repositoryCliente.BuscarPorId(id);
            if (clientes == null)
            {
                return View();
            }
            return View(clientes);
        }
        [HttpPost]
        public IActionResult Alterar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCliente.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, houve um erro ao alterar o cliente. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Cliente cliente = _repositoryCliente.BuscarPorId(id);
            return View(cliente);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _repositoryCliente.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir o cliente";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao excluir o cliente. Detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Detalhes(int id)
        {
            Cliente clientes = _repositoryCliente.BuscarPorId(id);
            if (clientes == null)
            {
                return View();
            }
            return View(clientes);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
