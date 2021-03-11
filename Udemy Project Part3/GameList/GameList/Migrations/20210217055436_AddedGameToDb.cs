 using Microsoft.EntityFrameworkCore.Migrations;

namespace GameList.Migrations
{
    public partial class AddedGameToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 1, "NFS", 3, 2010 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 2, "COC", 4, 2001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
