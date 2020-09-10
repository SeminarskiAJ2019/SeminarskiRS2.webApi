using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Database
{
    public partial class _170120Context
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId = 15,
                Naziv = "Italija"
            });
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId=16,
                Naziv="Hrvatska"
            });
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId = 17,
                Naziv = "Spanjolska"
            });
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId = 18,
                Naziv = "Engleska"
            });
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId = 19,
                Naziv = "Turska"
            });
            modelBuilder.Entity<Drzave>().HasData(new webApi.Database.Drzave()
            {
                DrzavaId = 20,
                Naziv = "USA"
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 15,
                Naziv = "Milan",
                GradId = 15
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 16,
                Naziv = "Zagreb",
                GradId = 16
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 17,
                Naziv = "Madrid",
                GradId = 17
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 18,
                Naziv = "London",
                GradId = 18
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 19,
                Naziv = "Ankara",
                GradId = 19
            });
            modelBuilder.Entity<Gradovi>().HasData(new webApi.Database.Gradovi()
            {
                DrzavaId = 20,
                Naziv = "Los Angeles",
                GradId = 20
            });
            List<string> Salt = new List<string>();
            for(int i = 0; i < 10; i++)
            {
                Salt.Add(HashHelper.GenerateSalt());
            };
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                DatumRodjenja = new DateTime(2010, 3, 24),
                Email = "desktop@gmail.com",
                Ime = "desktop",
                GradId = 18,
                KorisnickoIme = "desktop",
                KorisnikId = 15,
                Prezime = "desktop",
                Telefon = "063632111",
                LozinkaSalt = Salt[0],
                LozinkaHash = HashHelper.GenerateHash(Salt[0], "test")
            });
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                DatumRodjenja = new DateTime(2011, 4, 27),
                Email = "mobile@gmail.com",
                Ime = "mobile",
                GradId = 16,
                KorisnickoIme = "mobile",
                KorisnikId = 16,
                Prezime = "mobile",
                Telefon = "063632141",
                LozinkaSalt = Salt[1],
                LozinkaHash = HashHelper.GenerateHash(Salt[1], "test")
            });
            modelBuilder.Entity<Korisnici>().HasData(new webApi.Database.Korisnici()
            {
                DatumRodjenja = new DateTime(2009, 2, 13),
                Email = "dockertest@gmail.com",
                Ime = "dockertest",
                GradId = 17,
                KorisnickoIme = "dockertest",
                KorisnikId = 17,
                Prezime = "dockertest",
                Telefon = "063654123",
                LozinkaSalt = Salt[2],
                LozinkaHash = HashHelper.GenerateHash(Salt[2], "123456")
            });
        }
    }
}
