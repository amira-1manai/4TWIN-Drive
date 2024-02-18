using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exemples",
                table: "Exemples");

            migrationBuilder.RenameTable(
                name: "Exemples",
                newName: "Exemple");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exemple",
                table: "Exemple",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exemple",
                table: "Exemple");

            migrationBuilder.RenameTable(
                name: "Exemple",
                newName: "Exemples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exemples",
                table: "Exemples",
                column: "Id");
        }
    }
}
