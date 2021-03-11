using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeStore.Migrations
{
    public partial class AddedTypeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trees",
                keyColumn: "TreeId",
                keyValue: 1,
                column: "TypeId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trees",
                keyColumn: "TreeId",
                keyValue: 1,
                column: "TypeId",
                value: 2);
        }
    }
}
