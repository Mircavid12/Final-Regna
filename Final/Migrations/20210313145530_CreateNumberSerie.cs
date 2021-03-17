using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreateNumberSerie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyNumberSerie_Applies_ApplyId",
                table: "ApplyNumberSerie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplyNumberSerie",
                table: "ApplyNumberSerie");

            migrationBuilder.RenameTable(
                name: "ApplyNumberSerie",
                newName: "ApplyNumberSeries");

            migrationBuilder.RenameIndex(
                name: "IX_ApplyNumberSerie_ApplyId",
                table: "ApplyNumberSeries",
                newName: "IX_ApplyNumberSeries_ApplyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplyNumberSeries",
                table: "ApplyNumberSeries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PhoneSeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneSeries", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyNumberSeries_Applies_ApplyId",
                table: "ApplyNumberSeries",
                column: "ApplyId",
                principalTable: "Applies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyNumberSeries_Applies_ApplyId",
                table: "ApplyNumberSeries");

            migrationBuilder.DropTable(
                name: "PhoneSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplyNumberSeries",
                table: "ApplyNumberSeries");

            migrationBuilder.RenameTable(
                name: "ApplyNumberSeries",
                newName: "ApplyNumberSerie");

            migrationBuilder.RenameIndex(
                name: "IX_ApplyNumberSeries_ApplyId",
                table: "ApplyNumberSerie",
                newName: "IX_ApplyNumberSerie_ApplyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplyNumberSerie",
                table: "ApplyNumberSerie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyNumberSerie_Applies_ApplyId",
                table: "ApplyNumberSerie",
                column: "ApplyId",
                principalTable: "Applies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
