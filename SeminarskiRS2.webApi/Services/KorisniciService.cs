using AutoMapper;
using Microsoft.Extensions.Configuration;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using SeminarskiRS2.webApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;
        public KorisniciService(_170120Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public Korisnik Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnici.FirstOrDefault(x => x.KorisnickoIme.Equals(username, StringComparison.Ordinal));
            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, pass);
                if(hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnik>(user);
                }
            }
            return null;
        }

        public List<Model.Korisnik> Get(KorisnikSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Prezime));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Korisnik>>(list);
        }

        public Korisnik GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);
            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Korisnik Insert(KorisnikInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);
            if (request.Lozinka != request.PotvrdaLozinke)
            {
                throw new UserException("Lozinke se ne slažu! ");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Korisnik Update(int id, KorisnikInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                if(request.Lozinka != request.PotvrdaLozinke)
                {
                    throw new UserException("Passwordi se ne slažu! ");
                }
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}
