using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class StadioniInsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int GradID { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
