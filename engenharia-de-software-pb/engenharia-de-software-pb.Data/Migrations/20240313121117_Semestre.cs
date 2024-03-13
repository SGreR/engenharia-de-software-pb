using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace engenharia_de_software_pb.Data.Migrations
{
    public partial class Semestre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Semestre",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semestre",
                table: "Turmas");
        }
    }
}
