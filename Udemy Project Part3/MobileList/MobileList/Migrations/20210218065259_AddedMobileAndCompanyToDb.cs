using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileList.Migrations
{
    public partial class AddedMobileAndCompanyToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, "Xiaomi" },
                    { 2, "Samsung" },
                    { 3, "Nokia" },
                    { 4, "IPhone" }
                });

            migrationBuilder.InsertData(
                table: "Mobiles",
                columns: new[] { "Id", "CompanyId", "Name", "Price", "Rating" },
                values: new object[] { 1, 1, "Redmi note 7", 16000m, 4 });

            migrationBuilder.InsertData(
                table: "Mobiles",
                columns: new[] { "Id", "CompanyId", "Name", "Price", "Rating" },
                values: new object[] { 2, 2, "Pro Device", 15000m, 3 });

            migrationBuilder.InsertData(
                table: "Mobiles",
                columns: new[] { "Id", "CompanyId", "Name", "Price", "Rating" },
                values: new object[] { 3, 4, "Iphone 12", 160000m, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CompanyId",
                table: "Mobiles",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
