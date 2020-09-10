using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiRS2.webApi.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaID", "Naziv" },
                values: new object[] { 15, "Italija" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 15);
        }
    }
}
