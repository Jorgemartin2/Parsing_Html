using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_Livros.Models
{
    public class Cliente
    {
        public Cliente()
        {
            LivroClienteEmprestimo = new HashSet<LivroClienteEmprestimo>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("nome")]
        [MaxLength(100, ErrorMessage = "Nome do cliente maior que o permitido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("cpf")]
        [MaxLength(11, ErrorMessage = "CPF maior que o tamanho permitido.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("endereco")]
        [MaxLength(100, ErrorMessage = "Endereço maior que o permitido.")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("cidade")]
        [MaxLength(50, ErrorMessage = "Nome da cidade maior que o permitido.")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("bairro")]
        [StringLength(50, ErrorMessage = "Nome do bairro maior que o permitido")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("numero")]
        [StringLength(10, ErrorMessage = "Número do endereço maior que o permitido")]
        [DisplayName("Número")]
        public string Numero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("celular")]
        [StringLength(14, ErrorMessage = "Número celular maior que o permitido")]
        [DisplayName("Celular")]
        public string Celular { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Column("telFixo")]
        [StringLength(13, ErrorMessage = "Telefone fixo maior que o permitido")]
        [DisplayName("Telefone Fixo")]
        public string TelFixo { get; set; } = string.Empty;
        [InverseProperty("LceIdClienteNavigation")]
        public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }
    }
}