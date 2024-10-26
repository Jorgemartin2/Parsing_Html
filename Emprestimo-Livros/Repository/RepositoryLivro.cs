using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emprestimo_Livros.Data;
using Emprestimo_Livros.Interface;
using Emprestimo_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_Livros.Repository
{
    public class RepositoryLivro : IRepositoryLivro
    {
        private readonly SystemDbContext _bancoContext;
        public RepositoryLivro(SystemDbContext bancocontext)
        {
            _bancoContext = bancocontext;
        }
        public Livro Adicionar(Livro livro)
        {
            _bancoContext.Livro.Add(livro);
            _bancoContext.SaveChanges();
            return livro;
        }
        public List<Livro> BuscarLivros()
        {
            return _bancoContext.Livro.ToList();
        }
        public Livro BuscarPorId(int id)
        {
            return _bancoContext.Livro.FirstOrDefault(x => x.Id == id);
        }
        public Livro Atualizar(Livro livro)
        {
            Livro livroDb = BuscarPorId(livro.Id);
            if (livroDb == null) throw new Exception("Ops, houve um erro na atualização do livro.");
            livroDb.Nome = livro.Nome;
            livroDb.Autor = livro.Autor;
            livroDb.Editora = livro.Editora;
            livroDb.AnoPublicacao = livro.AnoPublicacao;
            _bancoContext.Livro.Update(livroDb);
            _bancoContext.SaveChanges();
            return livroDb;
        }
        public bool Apagar(int id)
        {
            Livro livroDb = BuscarPorId(id);
            if (livroDb == null) throw new System.Exception("Houve um erro na deleção do livro");
            _bancoContext.Livro.Remove(livroDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}