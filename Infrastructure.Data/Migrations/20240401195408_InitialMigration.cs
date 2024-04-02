using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ListaTarefa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsavel = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ListaTarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_ListaTarefa_ListaTarefaId",
                        column: x => x.ListaTarefaId,
                        principalSchema: "dbo",
                        principalTable: "ListaTarefa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Responsavel",
                schema: "dbo",
                table: "ListaTarefa",
                column: "Responsavel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ListaTarefaId",
                schema: "dbo",
                table: "Tarefa",
                column: "ListaTarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ListaTarefa",
                schema: "dbo");
        }
    }
}
