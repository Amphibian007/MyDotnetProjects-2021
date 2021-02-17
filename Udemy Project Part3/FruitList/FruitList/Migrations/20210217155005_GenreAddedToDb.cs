using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitList.Migrations
{
    public partial class GenreAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "Fruits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[] { "S", "Summer" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[] { "R", "Rainy Season" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[] { "A", "All Season" });

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreId",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Fruits",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreId",
                value: "S");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_GenreId",
                table: "Fruits",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Genre_GenreId",
                table: "Fruits",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Genre_GenreId",
                table: "Fruits");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_GenreId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Fruits");
        }
    }
}
