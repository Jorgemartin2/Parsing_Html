using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    telFixo = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    autor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    editora = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    anoPublicacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LivroClienteEmprestimo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdLivro = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime", nullable: false),
                    LivroEntregue = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroClienteEmprestimo", x => x.id);
                    table.ForeignKey(
                        name: "FK_LivroClienteEmprestimo_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroClienteEmprestimo_Livro_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroClienteEmprestimo_IdCliente",
                table: "LivroClienteEmprestimo",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_LivroClienteEmprestimo_IdLivro",
                table: "LivroClienteEmprestimo",
                column: "IdLivro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroClienteEmprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
