using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace engenharia_de_software_pb.Data.Migrations
{
    public partial class SPKCPID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassPerformanceId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakingId",
                table: "Notas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassPerformanceId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "SpeakingId",
                table: "Notas");
        }
    }
}
