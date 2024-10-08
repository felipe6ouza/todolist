using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todolist.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuncaoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncaoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPrioridade",
                columns: table => new
                {
                    PrioridadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPrioridade", x => x.PrioridadeId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    FuncaoUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_FuncaoUsuarios_FuncaoUsuarioId",
                        column: x => x.FuncaoUsuarioId,
                        principalTable: "FuncaoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Favorito = table.Column<bool>(type: "bit", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Usuarios_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    PrioridadeId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StatusTarefa = table.Column<int>(type: "int", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_StatusTarefa_StatusTarefa",
                        column: x => x.StatusTarefa,
                        principalTable: "StatusTarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_TiposPrioridade_PrioridadeId",
                        column: x => x.PrioridadeId,
                        principalTable: "TiposPrioridade",
                        principalColumn: "PrioridadeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoTarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Modificacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefas_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FuncaoUsuarios",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Colaborador" },
                    { 2, "Gerente" }
                });

            migrationBuilder.InsertData(
                table: "StatusTarefa",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 0, "Pendente" },
                    { 1, "Concluida" },
                    { 2, "Cancelada" },
                    { 3, "Arquivada" }
                });

            migrationBuilder.InsertData(
                table: "TiposPrioridade",
                columns: new[] { "PrioridadeId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Alta" },
                    { 2, "Media" },
                    { 3, "Baixa" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataNascimento", "FuncaoUsuarioId", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 10, 8, 2, 2, 48, 67, DateTimeKind.Local).AddTicks(6966), 1, "Felipe", "Souza" },
                    { 2, new DateTime(1970, 10, 8, 2, 2, 48, 67, DateTimeKind.Local).AddTicks(6995), 2, "Linus", "Towards" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_AutorId",
                table: "Comentarios",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TarefaId",
                table: "Comentarios",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefas_TarefaId",
                table: "HistoricoTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefas_UsuarioId",
                table: "HistoricoTarefas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_AutorId",
                table: "Projetos",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_AutorId",
                table: "Tarefas",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_PrioridadeId",
                table: "Tarefas",
                column: "PrioridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ResponsavelId",
                table: "Tarefas",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusTarefa",
                table: "Tarefas",
                column: "StatusTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncaoUsuarioId",
                table: "Usuarios",
                column: "FuncaoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "HistoricoTarefas");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "StatusTarefa");

            migrationBuilder.DropTable(
                name: "TiposPrioridade");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "FuncaoUsuarios");
        }
    }
}
