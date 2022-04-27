using Microsoft.EntityFrameworkCore.Migrations;

namespace DawaAPI.Migrations
{
    public partial class DawaAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surah",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arabicName = table.Column<string>(nullable: true),
                    englishName = table.Column<string>(nullable: true),
                    juza = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surah", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ayah",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idInSurah = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    pageNumber = table.Column<int>(nullable: false),
                    text_For_Html = table.Column<string>(nullable: true),
                    text_Emlaey = table.Column<string>(nullable: true),
                    surahId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayah", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ayah_Surah_surahId",
                        column: x => x.surahId,
                        principalTable: "Surah",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ayah_surahId",
                table: "Ayah",
                column: "surahId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayah");

            migrationBuilder.DropTable(
                name: "Surah");
        }
    }
}
