using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Survey.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldDB.Estados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    EEstadoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDB.Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldDB.Levantamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    Concluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDB.Levantamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldDB.Blocos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevantamentoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDB.Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDB.Blocos_FieldDB.Levantamentos_LevantamentoId",
                        column: x => x.LevantamentoId,
                        principalTable: "FieldDB.Levantamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldDB.Pavimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlocoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDB.Pavimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDB.Pavimentos_FieldDB.Blocos_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "FieldDB.Blocos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldDB.Luminarias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PavimentoId = table.Column<long>(type: "bigint", nullable: false),
                    EstadoId = table.Column<long>(type: "bigint", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDB.Luminarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDB.Luminarias_FieldDB.Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "FieldDB.Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldDB.Luminarias_FieldDB.Pavimentos_PavimentoId",
                        column: x => x.PavimentoId,
                        principalTable: "FieldDB.Pavimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FieldDB.Estados",
                columns: new[] { "Id", "Descricao", "EEstadoType" },
                values: new object[,]
                {
                    { 1L, "Primeira luminária do pavimento 1", 0 },
                    { 2L, "Primeira luminária do pavimento 2", 0 },
                    { 3L, "Primeira luminária do pavimento 3", 0 },
                    { 4L, "Primeira luminária do pavimento 4", 0 },
                    { 5L, "Primeira luminária do pavimento 5", 0 },
                    { 6L, "Primeira luminária do pavimento 6", 0 },
                    { 7L, "Primeira luminária do pavimento 7", 0 },
                    { 8L, "Primeira luminária do pavimento 8", 0 },
                    { 9L, "Primeira luminária do pavimento 9", 0 },
                    { 10L, "Primeira luminária do pavimento 10", 0 }
                });

            migrationBuilder.InsertData(
                table: "FieldDB.Levantamentos",
                columns: new[] { "Id", "Concluded", "Descricao", "FuncionarioId" },
                values: new object[,]
                {
                    { 1L, false, "Levantamento 1", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 2L, false, "Levantamento 2", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 3L, false, "Levantamento 3", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 4L, false, "Levantamento 4", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 5L, false, "Levantamento 5", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 6L, false, "Levantamento 6", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 7L, false, "Levantamento 7", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 8L, false, "Levantamento 8", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 9L, false, "Levantamento 9", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 10L, false, "Levantamento 10", new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") }
                });

            migrationBuilder.InsertData(
                table: "FieldDB.Blocos",
                columns: new[] { "Id", "Descricao", "LevantamentoId", "Nome" },
                values: new object[,]
                {
                    { 1L, "BLOCO A DO LEVANTAMENTO 1", 1L, "BLOCO A" },
                    { 2L, "BLOCO A DO LEVANTAMENTO 2", 2L, "BLOCO A" },
                    { 3L, "BLOCO A DO LEVANTAMENTO 3", 3L, "BLOCO A" },
                    { 4L, "BLOCO A DO LEVANTAMENTO 4", 4L, "BLOCO A" },
                    { 5L, "BLOCO A DO LEVANTAMENTO 5", 5L, "BLOCO A" },
                    { 6L, "BLOCO A DO LEVANTAMENTO 6", 6L, "BLOCO A" },
                    { 7L, "BLOCO A DO LEVANTAMENTO 7", 7L, "BLOCO A" },
                    { 8L, "BLOCO A DO LEVANTAMENTO 8", 8L, "BLOCO A" },
                    { 9L, "BLOCO A DO LEVANTAMENTO 9", 9L, "BLOCO A" },
                    { 10L, "BLOCO A DO LEVANTAMENTO 10", 10L, "BLOCO A" }
                });

            migrationBuilder.InsertData(
                table: "FieldDB.Pavimentos",
                columns: new[] { "Id", "BlocoId", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1L, 1L, "PAVIMENTO DO LEVANTAMENTO 1 DO BLOCO 1", "PAVIMENTO 1" },
                    { 2L, 2L, "PAVIMENTO DO LEVANTAMENTO 2 DO BLOCO 2", "PAVIMENTO 2" },
                    { 3L, 3L, "PAVIMENTO DO LEVANTAMENTO 3 DO BLOCO 3", "PAVIMENTO 3" },
                    { 4L, 4L, "PAVIMENTO DO LEVANTAMENTO 4 DO BLOCO 4", "PAVIMENTO 4" },
                    { 5L, 5L, "PAVIMENTO DO LEVANTAMENTO 5 DO BLOCO 5", "PAVIMENTO 5" },
                    { 6L, 6L, "PAVIMENTO DO LEVANTAMENTO 6 DO BLOCO 6", "PAVIMENTO 6" },
                    { 7L, 7L, "PAVIMENTO DO LEVANTAMENTO 7 DO BLOCO 7", "PAVIMENTO 7" },
                    { 8L, 8L, "PAVIMENTO DO LEVANTAMENTO 8 DO BLOCO 8", "PAVIMENTO 8" },
                    { 9L, 9L, "PAVIMENTO DO LEVANTAMENTO 9 DO BLOCO 9", "PAVIMENTO 9" },
                    { 10L, 10L, "PAVIMENTO DO LEVANTAMENTO 10 DO BLOCO 10", "PAVIMENTO 10" }
                });

            migrationBuilder.InsertData(
                table: "FieldDB.Luminarias",
                columns: new[] { "Id", "EstadoId", "Imagem", "PavimentoId" },
                values: new object[,]
                {
                    { 1L, 1L, "", 1L },
                    { 2L, 2L, "", 2L },
                    { 3L, 3L, "", 3L },
                    { 4L, 4L, "", 4L },
                    { 5L, 5L, "", 5L },
                    { 6L, 6L, "", 6L },
                    { 7L, 7L, "", 7L },
                    { 8L, 8L, "", 8L },
                    { 9L, 9L, "", 9L },
                    { 10L, 10L, "", 10L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldDB.Blocos_LevantamentoId",
                table: "FieldDB.Blocos",
                column: "LevantamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDB.Luminarias_EstadoId",
                table: "FieldDB.Luminarias",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDB.Luminarias_PavimentoId",
                table: "FieldDB.Luminarias",
                column: "PavimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDB.Pavimentos_BlocoId",
                table: "FieldDB.Pavimentos",
                column: "BlocoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldDB.Luminarias");

            migrationBuilder.DropTable(
                name: "FieldDB.Estados");

            migrationBuilder.DropTable(
                name: "FieldDB.Pavimentos");

            migrationBuilder.DropTable(
                name: "FieldDB.Blocos");

            migrationBuilder.DropTable(
                name: "FieldDB.Levantamentos");
        }
    }
}
