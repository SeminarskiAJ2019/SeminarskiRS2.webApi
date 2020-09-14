using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Database
{
    public partial class _170120Context
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            webApi.Database.Drzave Italija = new webApi.Database.Drzave()
            {
                DrzavaId = 1,
                Naziv = "Italija"
            };
            modelBuilder.Entity<Drzave>().HasData(Italija);
            webApi.Database.Drzave Hrvatska = new webApi.Database.Drzave()
            {
                DrzavaId = 2,
                Naziv = "Hrvatska"
            };
            modelBuilder.Entity<Drzave>().HasData(Hrvatska);
            webApi.Database.Drzave Spanjolska = new webApi.Database.Drzave()
            {
                DrzavaId = 3,
                Naziv = "Spanjolska"
            };
            modelBuilder.Entity<Drzave>().HasData(Spanjolska);
            webApi.Database.Drzave Engleska = new webApi.Database.Drzave()
            {
                DrzavaId = 4,
                Naziv = "Engleska"
            };
            modelBuilder.Entity<Drzave>().HasData(Engleska);
            webApi.Database.Drzave Turska = new webApi.Database.Drzave()
            {
                DrzavaId = 5,
                Naziv = "Turska"
            };
            modelBuilder.Entity<Drzave>().HasData(Turska);
            webApi.Database.Drzave USA = new webApi.Database.Drzave()
            {
                DrzavaId = 6,
                Naziv = "USA"
            };
            modelBuilder.Entity<Drzave>().HasData(USA);

            webApi.Database.Gradovi Milan = new webApi.Database.Gradovi()
            {  
                GradId=1,
                DrzavaId = 1,
                Naziv = "Milan"
            };
            modelBuilder.Entity<Gradovi>().HasData(Milan);
            webApi.Database.Gradovi Zagreb = new webApi.Database.Gradovi()
            {
                GradId = 2,
                DrzavaId = 2,
                Naziv = "Zagreb"
            };
            modelBuilder.Entity<Gradovi>().HasData(Zagreb);
            webApi.Database.Gradovi Madrid = new webApi.Database.Gradovi()
            {
                GradId = 3,
                DrzavaId = 3,
                Naziv = "Madrid"
            };
            modelBuilder.Entity<Gradovi>().HasData(Madrid);
            webApi.Database.Gradovi London = new webApi.Database.Gradovi()
            {
                GradId = 4,
                DrzavaId = 4,
                Naziv = "London"
            };
            modelBuilder.Entity<Gradovi>().HasData(London);
            webApi.Database.Gradovi Ankara = new webApi.Database.Gradovi()
            {
                GradId = 5,
                DrzavaId = 5,
                Naziv = "Ankara"
            };
            modelBuilder.Entity<Gradovi>().HasData(Ankara);
            webApi.Database.Gradovi LA = new webApi.Database.Gradovi()
            {
                GradId = 6,
                DrzavaId = 6,
                Naziv = "LA"
            };
            modelBuilder.Entity<Gradovi>().HasData(LA);
           
            List<string> Salt = new List<string>();
            for(int i = 0; i < 10; i++)
            {
                Salt.Add(HashHelper.GenerateSalt());
            };
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                KorisnikId = 1,
                DatumRodjenja = new DateTime(2010, 3, 24),
                Email = "desktop@gmail.com",
                Ime = "desktop",
                GradId = 1,
                KorisnickoIme = "desktop",
                Prezime = "desktop",
                Telefon = "063632111",
                LozinkaSalt = Salt[0],
                LozinkaHash = HashHelper.GenerateHash(Salt[0], "test")
            });
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                KorisnikId = 2,
                DatumRodjenja = new DateTime(2011, 4, 27),
                Email = "mobile@gmail.com",
                Ime = "mobile",
                GradId = 2,
                KorisnickoIme = "mobile",
                Prezime = "mobile",
                Telefon = "063632141",
                LozinkaSalt = Salt[1],
                LozinkaHash = HashHelper.GenerateHash(Salt[1], "test")
            });
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                KorisnikId = 3,
                DatumRodjenja = new DateTime(2009, 2, 13),
                Email = "dockertest@gmail.com",
                Ime = "dockertest",
                GradId = 3,
                KorisnickoIme = "dockertest",              
                Prezime = "dockertest",
                Telefon = "063654123",
                LozinkaSalt = Salt[2],
                LozinkaHash = HashHelper.GenerateHash(Salt[2], "123456")
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId=1,
                Naziv="Italija A1",
                DrzavaId=1
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId = 2,
                Naziv = "Hrvatska B1",
                DrzavaId = 2
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId = 3,
                Naziv = "Spanjolska A1",
                DrzavaId = 3
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId = 4,
                Naziv = "Engleska A1",
                DrzavaId = 4
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId = 5,
                Naziv = "Turska B1",
                DrzavaId = 5
            });
            modelBuilder.Entity<Lige>().HasData(new webApi.Database.Lige()
            {
                LigaId = 6,
                Naziv = "NBA",
                DrzavaId = 6
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId=1,
                Naziv="Milan arena",
                GradId=1,
                Opis="Arena u Milanu",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId = 2,
                Naziv = "Zagreb arena",
                GradId = 2,
                Opis = "Arena u Zagrebu",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId = 3,
                Naziv = "Madrid arena",
                GradId = 3,
                Opis = "Arena u Madridu",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId = 4,
                Naziv = "London arena",
                GradId = 4,
                Opis = "Arena u Londonu",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId = 5,
                Naziv = "Ankara arena",
                GradId = 5,
                Opis = "Arena u Ankari",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Stadioni>().HasData(new webApi.Database.Stadioni()
            {
                StadionId = 6,
                Naziv = "LA arena",
                GradId = 6,
                Opis = "Arena u LA-u",
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 1,
                Naziv = "Milan Sjeverna",
                StadionId = 1,
                Cijena = 40
            });
           
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 2,
                Naziv = "Zagreb Sjeverna",
                StadionId = 2,
                Cijena = 40
            });
            
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 3,
                Naziv = "Madrid Sjeverna",
                StadionId = 3,
                Cijena = 40
            });
           
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 4,
                Naziv = "London Sjeverna",
                StadionId = 4,
                Cijena = 40
            });
           
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 5,
                Naziv = "Ankara Sjeverna",
                StadionId = 5,
                Cijena = 40
            });
            
            modelBuilder.Entity<Tribine>().HasData(new webApi.Database.Tribine()
            {
                TribinaId = 6,
                Naziv = "LA North",
                StadionId = 6,
                Cijena = 40
            });

            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 1,
                Naziv = "A",
                TribinaId = 1,
            });
            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 2,
                Naziv = "A",
                TribinaId = 2,
            });
            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 3,
                Naziv = "A",
                TribinaId = 3,
            });
            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 4,
                Naziv = "A",
                TribinaId = 4,
            });
            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 5,
                Naziv = "A",
                TribinaId = 5,
            });
            modelBuilder.Entity<Sektori>().HasData(new webApi.Database.Sektori()
            {
                SektorId = 6,
                Naziv = "A",
                TribinaId = 6,
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 1,
                Oznaka = "1",
                SektorId = 1,
                Status = false
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 2,
                Oznaka = "2",
                SektorId = 2,
                Status = false
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 3,
                Oznaka = "3",
                SektorId = 3,
                Status = false
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 4,
                Oznaka = "4",
                SektorId = 4,
                Status = false
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 5,
                Oznaka = "5",
                SektorId = 5,
                Status = false
            });
            modelBuilder.Entity<Sjedala>().HasData(new webApi.Database.Sjedala()
            {
                SjedaloId = 6,
                Oznaka = "6",
                SektorId = 6,
                Status = false
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId=1,
                Naziv="Milan tim",
                Opis="Tim iz Milana",
                StadionId=1,
                LigaId=1,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId = 2,
                Naziv = "Cibona",
                Opis = "Tim iz Zagreba",
                StadionId = 2,
                LigaId = 2,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId = 3,
                Naziv = "Real Madrid",
                Opis = "Tim iz Madrida",
                StadionId = 3,
                LigaId = 3,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId = 4,
                Naziv = "London tim",
                Opis = "Tim iz Londona",
                StadionId = 4,
                LigaId = 4,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId = 5,
                Naziv = "Ankara tim",
                Opis = "Tim iz Ankare",
                StadionId = 5,
                LigaId = 5,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Timovi>().HasData(new webApi.Database.Timovi()
            {
                TimId = 6,
                Naziv = "LA Lakers",
                Opis = "Tim iz Los Angelesa",
                StadionId = 6,
                LigaId = 6,
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Utakmice>().HasData(new webApi.Database.Utakmice()
            {
                UtakmicaId = 1,
                DomaciTimId = 1,
                GostujuciTimId = 2,
                LigaId = 1,
                DatumOdigravanja = new DateTime(2021, 8, 21),
                VrijemeOdigravanja = new DateTime(2021, 8, 21, 16, 30, 0),
                StadionId = 1,
                Dateonly = new DateTime(2021, 8, 21),
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
            modelBuilder.Entity<Utakmice>().HasData(new webApi.Database.Utakmice()
            {
                UtakmicaId = 2,
                DomaciTimId = 3,
                GostujuciTimId = 4,
                LigaId = 3,
                DatumOdigravanja = new DateTime(2021, 9, 24),
                VrijemeOdigravanja = new DateTime(2021, 9, 24, 15, 30, 0),
                StadionId = 3,
                Dateonly = new DateTime(2021, 9, 24),
                Slika = File.ReadAllBytes("img/no_image.jpeg"),
                SlikaThumb = File.ReadAllBytes("img/no_image.jpeg")
            });
        }
    }
}
