using Microsoft.EntityFrameworkCore.Migrations;

namespace DawaAPI.Migrations
{
    public partial class changesforlooperror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Explanation_Ayah_AyahId",
                table: "Explanation");

            migrationBuilder.AlterColumn<int>(
                name: "AyahId",
                table: "Explanation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Explanation_Ayah_AyahId",
                table: "Explanation",
                column: "AyahId",
                principalTable: "Ayah",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Explanation_Ayah_AyahId",
                table: "Explanation");

            migrationBuilder.AlterColumn<int>(
                name: "AyahId",
                table: "Explanation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Explanation_Ayah_AyahId",
                table: "Explanation",
                column: "AyahId",
                principalTable: "Ayah",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
