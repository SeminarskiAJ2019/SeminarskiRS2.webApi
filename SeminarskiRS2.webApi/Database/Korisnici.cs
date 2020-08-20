using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            Preporuke = new HashSet<Preporuke>();
            Ulaznice = new HashSet<Ulaznice>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Korisnik { get { return Ime + " " + Prezime; } }
        public DateTime? DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public int GradId { get; set; }

        public Gradovi Grad { get; set; }
        public ICollection<Preporuke> Preporuke { get; set; }
        public ICollection<Ulaznice> Ulaznice { get; set; }
    }
}
