using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_Livros.Models
{
    public partial class LivroClienteEmprestimo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdCliente { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DisplayName("Data Empréstimo")]
        public DateTime DataEmprestimo { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DisplayName("Data Devolução")]
        public DateTime DataDevolucao { get; set; }
        [DisplayName("Livro Entregue")]
        public bool LivroEntregue { get; set; }
        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.LivroClienteEmprestimo))]
        public virtual Cliente LceIdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(Livro.LivroClienteEmprestimo))]
        public virtual Livro LceIdLivroNavigation { get; set; }
    }
}