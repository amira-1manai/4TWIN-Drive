using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Data.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MailParticipant",
                table: "Participants",
                newName: "MyName");

            migrationBuilder.RenameColumn(
                name: "MailEntreprise",
                table: "Entreprises",
                newName: "MyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyName",
                table: "Participants",
                newName: "MailParticipant");

            migrationBuilder.RenameColumn(
                name: "MyName",
                table: "Entreprises",
                newName: "MailEntreprise");
        }
    }
}
