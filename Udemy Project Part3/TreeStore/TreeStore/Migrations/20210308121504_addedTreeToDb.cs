using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeStore.Migrations
{
    public partial class addedTreeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "TreeId", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "Mango Tree", 4, 2001 },
                    { 2, "Cocunut Tree", 3, 2010 },
                    { 3, "Banyan Tree", 5, 2020 },
                    { 4, "Berry Tree", 3, 2015 },
                    { 5, "Jackfruit Tree", 5, 2010 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trees");
        }
    }
}
