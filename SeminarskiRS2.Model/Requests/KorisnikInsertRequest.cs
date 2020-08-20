using System;
using System.Collections.Generic;

using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class KorisnikInsertRequest
    {
       
        public string Ime { get; set; }
       
        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public int GradID { get; set; }
      
        public string Telefon { get; set; }
       
        public string Email { get; set; }
       
        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public string PotvrdaLozinke { get; set; }
    }
}
