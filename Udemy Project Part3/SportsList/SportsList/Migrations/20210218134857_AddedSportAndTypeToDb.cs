using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsList.Migrations
{
    public partial class AddedSportAndTypeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sports_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Indoor" },
                    { 2, "Outdoor" },
                    { 3, "Mobile" },
                    { 4, "PC" },
                    { 5, "Console" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "Price", "Rating", "TypeId" },
                values: new object[] { 1, "Ludu", 50m, 5, 1 });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "Price", "Rating", "TypeId" },
                values: new object[] { 2, "Football", 1000m, 5, 2 });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "Price", "Rating", "TypeId" },
                values: new object[] { 3, "Fifa 20", 20000m, 4, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Sports_TypeId",
                table: "Sports",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
