using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Interface
{
    public interface IRepositoryCliente
    {
        List<Cliente> BuscarClientes();
        Cliente BuscarPorId(int id);
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
    }
}