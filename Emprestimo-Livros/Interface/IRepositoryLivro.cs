using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Interface
{
    public interface IRepositoryLivro
    {
        List<Livro> BuscarLivros();
        Livro Adicionar(Livro livro);
        Livro BuscarPorId(int id);
        Livro Atualizar(Livro livro);
        bool Apagar(int id);
    }
}