using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KorisnikPodaci { get { return Ime + " " + Prezime; } }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string Lozinka { get; set; }
        public string PotvrdaLozinke { get; set; }
    }
}
