using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turns.Migrations
{
    public partial class Migration_TurnEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatienId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DoctorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.TurnId);
                    table.ForeignKey(
                        name: "FK_Turns_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_Patients_PatienId",
                        column: x => x.PatienId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turns_DoctorId",
                table: "Turns",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_PatienId",
                table: "Turns",
                column: "PatienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turns");
        }
    }
}
