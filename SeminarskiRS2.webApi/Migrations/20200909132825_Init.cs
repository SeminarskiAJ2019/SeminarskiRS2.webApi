using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiRS2.webApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 35, nullable: false),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradID);
                    table.ForeignKey(
                        name: "FK__Gradovi__DrzavaI__398D8EEE",
                        column: x => x.DrzavaID,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lige",
                columns: table => new
                {
                    LigaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lige", x => x.LigaID);
                    table.ForeignKey(
                        name: "FK__Lige__DrzavaID__3F466844",
                        column: x => x.DrzavaID,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 35, nullable: true),
                    Prezime = table.Column<string>(maxLength: 35, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime", nullable: true),
                    Telefon = table.Column<string>(maxLength: 35, nullable: true),
                    Email = table.Column<string>(maxLength: 35, nullable: true),
                    KorisnickoIme = table.Column<string>(maxLength: 60, nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK__Korisnici__GradI__3C69FB99",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stadioni",
                columns: table => new
                {
                    StadionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadioni", x => x.StadionID);
                    table.ForeignKey(
                        name: "FK__Stadioni__GradID__4222D4EF",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timovi",
                columns: table => new
                {
                    TimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    StadionID = table.Column<int>(nullable: false),
                    LigaID = table.Column<int>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: false),
                    SlikaThumb = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timovi", x => x.TimID);
                    table.ForeignKey(
                        name: "FK__Timovi__LigaID__45F365D3",
                        column: x => x.LigaID,
                        principalTable: "Lige",
                        principalColumn: "LigaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Timovi__StadionI__44FF419A",
                        column: x => x.StadionID,
                        principalTable: "Stadioni",
                        principalColumn: "StadionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tribine",
                columns: table => new
                {
                    TribinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    StadionID = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribine", x => x.TribinaID);
                    table.ForeignKey(
                        name: "FK__Tribine__Stadion__4CA06362",
                        column: x => x.StadionID,
                        principalTable: "Stadioni",
                        principalColumn: "StadionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preporuke",
                columns: table => new
                {
                    PreporukaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikID = table.Column<int>(nullable: false),
                    TimID = table.Column<int>(nullable: false),
                    BrojKupljenihUlaznica = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preporuke", x => x.PreporukaID);
                    table.ForeignKey(
                        name: "FK__Preporuke__Koris__48CFD27E",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Preporuke__TimID__49C3F6B7",
                        column: x => x.TimID,
                        principalTable: "Timovi",
                        principalColumn: "TimID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utakmice",
                columns: table => new
                {
                    UtakmicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DomaciTimID = table.Column<int>(nullable: false),
                    GostujuciTimID = table.Column<int>(nullable: false),
                    LigaID = table.Column<int>(nullable: false),
                    DatumOdigravanja = table.Column<DateTime>(nullable: false),
                    VrijemeOdigravanja = table.Column<DateTime>(nullable: false),
                    StadionID = table.Column<int>(nullable: false),
                    Dateonly = table.Column<DateTime>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmice", x => x.UtakmicaID);
                    table.ForeignKey(
                        name: "FK__Utakmice__Domaci__5535A963",
                        column: x => x.DomaciTimID,
                        principalTable: "Timovi",
                        principalColumn: "TimID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Utakmice__Gostuj__5629CD9C",
                        column: x => x.GostujuciTimID,
                        principalTable: "Timovi",
                        principalColumn: "TimID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Utakmice__LigaID__571DF1D5",
                        column: x => x.LigaID,
                        principalTable: "Lige",
                        principalColumn: "LigaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Utakmice__Stadio__5812160E",
                        column: x => x.StadionID,
                        principalTable: "Stadioni",
                        principalColumn: "StadionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sektori",
                columns: table => new
                {
                    SektorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    TribinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektori", x => x.SektorID);
                    table.ForeignKey(
                        name: "FK__Sektori__Tribina__4F7CD00D",
                        column: x => x.TribinaID,
                        principalTable: "Tribine",
                        principalColumn: "TribinaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sjedala",
                columns: table => new
                {
                    SjedaloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Oznaka = table.Column<string>(nullable: false),
                    SektorID = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjedala", x => x.SjedaloID);
                    table.ForeignKey(
                        name: "FK__Sjedala__SektorI__52593CB8",
                        column: x => x.SektorID,
                        principalTable: "Sektori",
                        principalColumn: "SektorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ulaznice",
                columns: table => new
                {
                    UlaznicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SjedaloID = table.Column<int>(nullable: false),
                    UtakmicaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    DatumKupnje = table.Column<DateTime>(nullable: false),
                    VrijemeKupnje = table.Column<DateTime>(nullable: false),
                    Barcodeimg = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaznice", x => x.UlaznicaID);
                    table.ForeignKey(
                        name: "FK__Ulaznice__Korisn__5CD6CB2B",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ulaznice__Sjedal__5AEE82B9",
                        column: x => x.SjedaloID,
                        principalTable: "Sjedala",
                        principalColumn: "SjedaloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ulaznice__Utakmi__5BE2A6F2",
                        column: x => x.UtakmicaID,
                        principalTable: "Utakmice",
                        principalColumn: "UtakmicaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UlaznicaID = table.Column<int>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK__Uplate__Ulaznica__5FB337D6",
                        column: x => x.UlaznicaID,
                        principalTable: "Ulaznice",
                        principalColumn: "UlaznicaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_DrzavaID",
                table: "Gradovi",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_GradID",
                table: "Korisnici",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Lige_DrzavaID",
                table: "Lige",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Preporuke_KorisnikID",
                table: "Preporuke",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Preporuke_TimID",
                table: "Preporuke",
                column: "TimID");

            migrationBuilder.CreateIndex(
                name: "IX_Sektori_TribinaID",
                table: "Sektori",
                column: "TribinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjedala_SektorID",
                table: "Sjedala",
                column: "SektorID");

            migrationBuilder.CreateIndex(
                name: "IX_Stadioni_GradID",
                table: "Stadioni",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_LigaID",
                table: "Timovi",
                column: "LigaID");

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_StadionID",
                table: "Timovi",
                column: "StadionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tribine_StadionID",
                table: "Tribine",
                column: "StadionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznice_KorisnikID",
                table: "Ulaznice",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznice_SjedaloID",
                table: "Ulaznice",
                column: "SjedaloID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznice_UtakmicaID",
                table: "Ulaznice",
                column: "UtakmicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_UlaznicaID",
                table: "Uplate",
                column: "UlaznicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_DomaciTimID",
                table: "Utakmice",
                column: "DomaciTimID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_GostujuciTimID",
                table: "Utakmice",
                column: "GostujuciTimID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_LigaID",
                table: "Utakmice",
                column: "LigaID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_StadionID",
                table: "Utakmice",
                column: "StadionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preporuke");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "Ulaznice");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Sjedala");

            migrationBuilder.DropTable(
                name: "Utakmice");

            migrationBuilder.DropTable(
                name: "Sektori");

            migrationBuilder.DropTable(
                name: "Timovi");

            migrationBuilder.DropTable(
                name: "Tribine");

            migrationBuilder.DropTable(
                name: "Lige");

            migrationBuilder.DropTable(
                name: "Stadioni");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
