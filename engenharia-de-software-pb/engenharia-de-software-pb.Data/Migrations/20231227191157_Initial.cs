using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace engenharia_de_software_pb.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassPerformances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresenceGrade = table.Column<int>(type: "int", nullable: false),
                    HomeworkGrade = table.Column<int>(type: "int", nullable: false),
                    ParticipationGrade = table.Column<int>(type: "int", nullable: false),
                    BehaviorGrade = table.Column<int>(type: "int", nullable: false),
                    NotasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPerformances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: true),
                    NumeroTeste = table.Column<int>(type: "int", nullable: false),
                    ReadingId = table.Column<int>(type: "int", nullable: true),
                    WritingId = table.Column<int>(type: "int", nullable: true),
                    ListeningId = table.Column<int>(type: "int", nullable: true),
                    GrammarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotaSimples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiraNota = table.Column<double>(type: "float", nullable: false),
                    SegundaNota = table.Column<double>(type: "float", nullable: false),
                    NotasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaSimples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaSimples_Notas_NotasId",
                        column: x => x.NotasId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speakings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionAndFluencyGrade = table.Column<int>(type: "int", nullable: false),
                    SpokenInteractionGrade = table.Column<int>(type: "int", nullable: false),
                    LanguageRangeGrade = table.Column<int>(type: "int", nullable: false),
                    AccuracyGrade = table.Column<int>(type: "int", nullable: false),
                    L2Use = table.Column<int>(type: "int", nullable: false),
                    NotasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakings_Notas_NotasId",
                        column: x => x.NotasId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassPerformances_NotasId",
                table: "ClassPerformances",
                column: "NotasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_GrammarId",
                table: "Notas",
                column: "GrammarId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ListeningId",
                table: "Notas",
                column: "ListeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ReadingId",
                table: "Notas",
                column: "ReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_WritingId",
                table: "Notas",
                column: "WritingId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaSimples_NotasId",
                table: "NotaSimples",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakings_NotasId",
                table: "Speakings",
                column: "NotasId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassPerformances_Notas_NotasId",
                table: "ClassPerformances",
                column: "NotasId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_NotaSimples_GrammarId",
                table: "Notas",
                column: "GrammarId",
                principalTable: "NotaSimples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_NotaSimples_ListeningId",
                table: "Notas",
                column: "ListeningId",
                principalTable: "NotaSimples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_NotaSimples_ReadingId",
                table: "Notas",
                column: "ReadingId",
                principalTable: "NotaSimples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_NotaSimples_WritingId",
                table: "Notas",
                column: "WritingId",
                principalTable: "NotaSimples",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaSimples_Notas_NotasId",
                table: "NotaSimples");

            migrationBuilder.DropTable(
                name: "ClassPerformances");

            migrationBuilder.DropTable(
                name: "Speakings");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "NotaSimples");
        }
    }
}
