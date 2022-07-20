using Microsoft.EntityFrameworkCore.Migrations;

namespace Turns.Migrations
{
    public partial class Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    IdSpeciality = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.IdSpeciality);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}
