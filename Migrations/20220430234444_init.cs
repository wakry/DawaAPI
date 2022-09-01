using Microsoft.EntityFrameworkCore.Migrations;

namespace DawaAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExplanationSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplanationSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surah",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arabicName = table.Column<string>(nullable: true),
                    englishName = table.Column<string>(nullable: true),
                    juza = table.Column<int>(nullable: false),
                    numberOfPages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surah", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ayah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInSurah = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    PageNumber = table.Column<int>(nullable: false),
                    TextForHtml = table.Column<string>(nullable: true),
                    TextEmlaey = table.Column<string>(nullable: true),
                    SurahId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayah", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ayah_Surah_SurahId",
                        column: x => x.SurahId,
                        principalTable: "Surah",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Explanation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(nullable: true),
                    ExplanationText = table.Column<string>(nullable: true),
                    AyahId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explanation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Explanation_Ayah_AyahId",
                        column: x => x.AyahId,
                        principalTable: "Ayah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Explanation_ExplanationSource_SourceId",
                        column: x => x.SourceId,
                        principalTable: "ExplanationSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ayah_SurahId",
                table: "Ayah",
                column: "SurahId");

            migrationBuilder.CreateIndex(
                name: "IX_Explanation_AyahId",
                table: "Explanation",
                column: "AyahId");

            migrationBuilder.CreateIndex(
                name: "IX_Explanation_SourceId",
                table: "Explanation",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Explanation");

            migrationBuilder.DropTable(
                name: "Ayah");

            migrationBuilder.DropTable(
                name: "ExplanationSource");

            migrationBuilder.DropTable(
                name: "Surah");
        }
    }
}
