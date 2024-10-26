using Emprestimo_Livros.Data;
using Emprestimo_Livros.Interface;
using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Repository
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly SystemDbContext _bancoContext;
        public RepositoryCliente(SystemDbContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public List<Cliente> BuscarClientes()
        {
            return _bancoContext.Cliente.ToList();
        }
        public Cliente BuscarPorId(int id)
        {
            return _bancoContext.Cliente.FirstOrDefault(x => x.Id == id);
        }
        public Cliente Adicionar(Cliente cliente)
        {
            _bancoContext.Cliente.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }
        public Cliente Atualizar(Cliente cliente)
        {
            Cliente clienteDb = BuscarPorId(cliente.Id);
            if (clienteDb == null) throw new Exception("Houve um erro na atualização do cliente.");
            clienteDb.Nome = cliente.Nome;
            clienteDb.Cpf = cliente.Cpf;
            clienteDb.Endereco = cliente.Endereco;
            clienteDb.Numero = cliente.Numero;
            clienteDb.Bairro = cliente.Bairro;
            clienteDb.Cidade = cliente.Cidade;
            clienteDb.Celular = cliente.Celular;
            clienteDb.TelFixo = cliente.TelFixo;
            _bancoContext.Cliente.Update(clienteDb);
            _bancoContext.SaveChanges();
            return clienteDb;
        }
        public bool Apagar(int id)
        {
            Cliente clienteDb = BuscarPorId(id);
            if (clienteDb == null) throw new System.Exception("Houve um erro na deleção do cliente");
            _bancoContext.Cliente.Remove(clienteDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}