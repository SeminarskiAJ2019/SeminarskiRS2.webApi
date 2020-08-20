using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SeminarskiRS2.webApi.Services
{
    public interface IKorisniciService
    {
        List<Model.Korisnik> Get(KorisnikSearchRequest request);
        Model.Korisnik GetById(int id);
        Model.Korisnik Update(int id, KorisnikInsertRequest request);
        Model.Korisnik Authenticiraj(string username, string pass);

        Model.Korisnik Insert(KorisnikInsertRequest request);
    }
}
