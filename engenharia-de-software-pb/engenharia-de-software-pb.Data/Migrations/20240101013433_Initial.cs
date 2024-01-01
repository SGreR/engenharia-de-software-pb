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
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    PresenceGrade = table.Column<int>(type: "int", nullable: false),
                    HomeworkGrade = table.Column<int>(type: "int", nullable: false),
                    ParticipationGrade = table.Column<int>(type: "int", nullable: false),
                    BehaviorGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPerformances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grammars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    PrimeiraNota = table.Column<double>(type: "float", nullable: false),
                    SegundaNota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grammars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    PrimeiraNota = table.Column<double>(type: "float", nullable: false),
                    SegundaNota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listenings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    NumeroTeste = table.Column<int>(type: "int", nullable: false),
                    ReadingId = table.Column<int>(type: "int", nullable: true),
                    WritingId = table.Column<int>(type: "int", nullable: true),
                    ListeningId = table.Column<int>(type: "int", nullable: true),
                    GrammarId = table.Column<int>(type: "int", nullable: true),
                    SpeakingId = table.Column<int>(type: "int", nullable: true),
                    ClassPerformanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_ClassPerformances_ClassPerformanceId",
                        column: x => x.ClassPerformanceId,
                        principalTable: "ClassPerformances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Grammars_GrammarId",
                        column: x => x.GrammarId,
                        principalTable: "Grammars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Listenings_ListeningId",
                        column: x => x.ListeningId,
                        principalTable: "Listenings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    PrimeiraNota = table.Column<double>(type: "float", nullable: false),
                    SegundaNota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Notas_NotasId",
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
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    ProductionAndFluencyGrade = table.Column<int>(type: "int", nullable: false),
                    SpokenInteractionGrade = table.Column<int>(type: "int", nullable: false),
                    LanguageRangeGrade = table.Column<int>(type: "int", nullable: false),
                    AccuracyGrade = table.Column<int>(type: "int", nullable: false),
                    L2Use = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Writings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    PrimeiraNota = table.Column<double>(type: "float", nullable: false),
                    SegundaNota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Writings_Notas_NotasId",
                        column: x => x.NotasId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassPerformances_NotasId",
                table: "ClassPerformances",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Grammars_NotasId",
                table: "Grammars",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Listenings_NotasId",
                table: "Listenings",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClassPerformanceId",
                table: "Notas",
                column: "ClassPerformanceId");

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
                name: "IX_Notas_SpeakingId",
                table: "Notas",
                column: "SpeakingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_WritingId",
                table: "Notas",
                column: "WritingId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_NotasId",
                table: "Readings",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakings_NotasId",
                table: "Speakings",
                column: "NotasId");

            migrationBuilder.CreateIndex(
                name: "IX_Writings_NotasId",
                table: "Writings",
                column: "NotasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassPerformances_Notas_NotasId",
                table: "ClassPerformances",
                column: "NotasId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grammars_Notas_NotasId",
                table: "Grammars",
                column: "NotasId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listenings_Notas_NotasId",
                table: "Listenings",
                column: "NotasId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Readings_ReadingId",
                table: "Notas",
                column: "ReadingId",
                principalTable: "Readings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Speakings_SpeakingId",
                table: "Notas",
                column: "SpeakingId",
                principalTable: "Speakings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Writings_WritingId",
                table: "Notas",
                column: "WritingId",
                principalTable: "Writings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassPerformances_Notas_NotasId",
                table: "ClassPerformances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grammars_Notas_NotasId",
                table: "Grammars");

            migrationBuilder.DropForeignKey(
                name: "FK_Listenings_Notas_NotasId",
                table: "Listenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Notas_NotasId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakings_Notas_NotasId",
                table: "Speakings");

            migrationBuilder.DropForeignKey(
                name: "FK_Writings_Notas_NotasId",
                table: "Writings");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "ClassPerformances");

            migrationBuilder.DropTable(
                name: "Grammars");

            migrationBuilder.DropTable(
                name: "Listenings");

            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Speakings");

            migrationBuilder.DropTable(
                name: "Writings");
        }
    }
}
