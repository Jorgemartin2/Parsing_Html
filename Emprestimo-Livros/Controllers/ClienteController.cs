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
        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repositoryCliente.Adicionar(cliente);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repositoryCliente.Atualizar(cliente);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var clientes = _repositoryCliente.BuscarPorId(id);
            if (clientes == null)
            {
                return View();
            }
            return View(clientes);
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
        public IActionResult ApagarConfirmacao(int id)
        {
            var clientes = _repositoryCliente.BuscarPorId(id);
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
