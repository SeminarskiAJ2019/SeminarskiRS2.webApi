using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiRS2.webApi.Migrations
{
    public partial class Korisnici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 15,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "WkDpmQdJY7Fp8ukYrHwcohsiVfk=", "W0GsP0kOtaIuNnWf0pKUOQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 16,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "6OthA4yW5YlV5MCiV/0+CoCEzpk=", "e8wjoTUAilCeb4wFryfE8g==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 17,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "7g1bfb5eXLNfU8olg0VjBvuVVZw=", "cgJNHMDenErZaFm1jxD1ow==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 15,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "XCihcxcPXWIUnvZZiLpp+6LXuh0=", "Rx2oYbJ9Y9V4D/RlmQVduA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 16,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "S100/RA3y20c7+CdMldxKXd+M6o=", "neB8Kpv3SdXwjcfsVhDhQA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 17,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "O7CXBNBpYBFDBJvZ24uWfOj/A78=", "rxI9DzFMh8BIJWCk8Br3ow==" });
        }
    }
}
