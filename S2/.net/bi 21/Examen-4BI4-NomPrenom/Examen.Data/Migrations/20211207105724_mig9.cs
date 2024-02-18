using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Data.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Cagnottes_CagnotteId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_CagnotteId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "CagnotteId",
                table: "Participants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CagnotteId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CagnotteId",
                table: "Participants",
                column: "CagnotteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Cagnottes_CagnotteId",
                table: "Participants",
                column: "CagnotteId",
                principalTable: "Cagnottes",
                principalColumn: "CagnotteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
