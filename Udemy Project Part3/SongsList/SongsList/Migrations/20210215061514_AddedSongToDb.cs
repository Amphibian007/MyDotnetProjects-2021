using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class AddedSongToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
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
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 1, "Pal pal", 5, 2002 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 2, "Bhoolbhulaiya", 4, 2001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
