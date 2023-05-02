using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turns.Migrations
{
    public partial class ReinstallSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Patients_PatienId",
                table: "Turns");

            migrationBuilder.RenameColumn(
                name: "PatienId",
                table: "Turns",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Turns_PatienId",
                table: "Turns",
                newName: "IX_Turns_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Patients_PatientId",
                table: "Turns",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Patients_PatientId",
                table: "Turns");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Turns",
                newName: "PatienId");

            migrationBuilder.RenameIndex(
                name: "IX_Turns_PatientId",
                table: "Turns",
                newName: "IX_Turns_PatienId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Patients_PatienId",
                table: "Turns",
                column: "PatienId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
