using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class CandidatoVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCandidatoVaga_AspNetUsers_UsuarioId",
                table: "tbCandidatoVaga");

            migrationBuilder.DropForeignKey(
                name: "FK_tbCandidatoVaga_tbVagaEmprego_VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga");

            migrationBuilder.DropIndex(
                name: "IX_tbCandidatoVaga_VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbCandidatoVaga");

            migrationBuilder.DropColumn(
                name: "VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga");

            migrationBuilder.RenameColumn(
                name: "IdVaga",
                table: "tbCandidatoVaga",
                newName: "VagaEmpregoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "tbCandidatoVaga",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoVaga_VagaEmpregoId",
                table: "tbCandidatoVaga",
                column: "VagaEmpregoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCandidatoVaga_AspNetUsers_UsuarioId",
                table: "tbCandidatoVaga",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbCandidatoVaga_tbVagaEmprego_VagaEmpregoId",
                table: "tbCandidatoVaga",
                column: "VagaEmpregoId",
                principalTable: "tbVagaEmprego",
                principalColumn: "IdVagaEmprego",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCandidatoVaga_AspNetUsers_UsuarioId",
                table: "tbCandidatoVaga");

            migrationBuilder.DropForeignKey(
                name: "FK_tbCandidatoVaga_tbVagaEmprego_VagaEmpregoId",
                table: "tbCandidatoVaga");

            migrationBuilder.DropIndex(
                name: "IX_tbCandidatoVaga_VagaEmpregoId",
                table: "tbCandidatoVaga");

            migrationBuilder.RenameColumn(
                name: "VagaEmpregoId",
                table: "tbCandidatoVaga",
                newName: "IdVaga");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "tbCandidatoVaga",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "tbCandidatoVaga",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoVaga_VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga",
                column: "VagasEmpregoIdVagaEmprego");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCandidatoVaga_AspNetUsers_UsuarioId",
                table: "tbCandidatoVaga",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCandidatoVaga_tbVagaEmprego_VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga",
                column: "VagasEmpregoIdVagaEmprego",
                principalTable: "tbVagaEmprego",
                principalColumn: "IdVagaEmprego");
        }
    }
}
