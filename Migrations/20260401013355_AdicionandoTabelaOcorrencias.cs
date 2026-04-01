using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiweb.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelaOcorrencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titulo = table.Column<string>(type: "TEXT", nullable: false),
                    detalhes = table.Column<string>(type: "TEXT", nullable: false),
                    dataOcorrencia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    usuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_usuarioId",
                table: "Ocorrencias",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrencias");
        }
    }
}
