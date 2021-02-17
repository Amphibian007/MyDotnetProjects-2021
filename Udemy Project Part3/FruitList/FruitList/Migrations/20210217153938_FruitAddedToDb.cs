using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitList.Migrations
{
    public partial class FruitAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fruits",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 1, "Banana", 3, 2008 });

            migrationBuilder.InsertData(
                table: "Fruits",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 2, "Jack Fruit", 4, 2005 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruits");
        }
    }
}
