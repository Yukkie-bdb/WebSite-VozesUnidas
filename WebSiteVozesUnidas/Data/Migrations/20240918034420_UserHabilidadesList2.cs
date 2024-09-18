using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserHabilidadesList2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Habilidades",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilidades",
                table: "AspNetUsers");
        }
    }
}
