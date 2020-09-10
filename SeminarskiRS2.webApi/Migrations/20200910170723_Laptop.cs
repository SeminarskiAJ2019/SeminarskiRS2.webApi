using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiRS2.webApi.Migrations
{
    public partial class Laptop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 16, "Hrvatska" },
                    { 17, "Spanjolska" },
                    { 18, "Engleska" },
                    { 19, "Turska" },
                    { 20, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "GradID", "DrzavaID", "Naziv" },
                values: new object[] { 15, 15, "Milan" });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "GradID", "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 16, 16, "Zagreb" },
                    { 17, 17, "Madrid" },
                    { 18, 18, "London" },
                    { 19, 19, "Ankara" },
                    { 20, 20, "Los Angeles" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "DatumRodjenja", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon" },
                values: new object[] { 16, new DateTime(2011, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile@gmail.com", 16, "mobile", "mobile", "S100/RA3y20c7+CdMldxKXd+M6o=", "neB8Kpv3SdXwjcfsVhDhQA==", "mobile", "063632141" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "DatumRodjenja", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon" },
                values: new object[] { 17, new DateTime(2009, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "dockertest@gmail.com", 17, "dockertest", "dockertest", "O7CXBNBpYBFDBJvZ24uWfOj/A78=", "rxI9DzFMh8BIJWCk8Br3ow==", "dockertest", "063654123" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "DatumRodjenja", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon" },
                values: new object[] { 15, new DateTime(2010, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop@gmail.com", 18, "desktop", "desktop", "XCihcxcPXWIUnvZZiLpp+6LXuh0=", "Rx2oYbJ9Y9V4D/RlmQVduA==", "desktop", "063632111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 18);
        }
    }
}
