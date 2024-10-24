using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options){}
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
        }
    }
}