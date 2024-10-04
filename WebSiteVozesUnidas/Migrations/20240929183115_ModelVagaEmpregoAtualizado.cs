using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class ModelVagaEmpregoAtualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResumoVaga",
                table: "tbVagaEmprego",
                newName: "RegimeContratacao");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "tbVagaEmprego",
                newName: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "tbVagaEmprego",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroVagas",
                table: "tbVagaEmprego",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Publicacao",
                table: "tbVagaEmprego",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Salario",
                table: "tbVagaEmprego",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "tbVagaEmprego");

            migrationBuilder.DropColumn(
                name: "NumeroVagas",
                table: "tbVagaEmprego");

            migrationBuilder.DropColumn(
                name: "Publicacao",
                table: "tbVagaEmprego");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "tbVagaEmprego");

            migrationBuilder.RenameColumn(
                name: "RegimeContratacao",
                table: "tbVagaEmprego",
                newName: "ResumoVaga");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "tbVagaEmprego",
                newName: "Foto");
        }
    }
}
