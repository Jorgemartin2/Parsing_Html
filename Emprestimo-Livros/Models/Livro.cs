using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Emprestimo_Livros.Models
{
    public class Livro
    {
        public Livro()
        {
            LivroClienteEmprestimo = new HashSet<LivroClienteEmprestimo>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("nome")]
        [MaxLength(50, ErrorMessage = "Nome do livro maior que o permitido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("autor")]
        [MaxLength(50, ErrorMessage = "Nome do autor maior que o permitido.")]
        [DisplayName("Autor")]
        public string Autor { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("editora")]
        [MaxLength(50, ErrorMessage = "Nome da editora maior que o permitido.")]
        [DisplayName("Editora")]
        public string Editora { get; set; } = string.Empty;
        [Column("anoPublicacao", TypeName = "datetime")]
        [DisplayName("Ano Publicação")]
        public DateTime AnoPublicacao { get; set; }
        [InverseProperty("LceIdLivroNavigation")]
        public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }
    }
}