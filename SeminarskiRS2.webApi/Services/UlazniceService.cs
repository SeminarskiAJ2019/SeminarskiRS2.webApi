using AutoMapper;
using QRCoder;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class UlazniceService : BaseCRUDService<Model.Ulaznice, UlazniceSearchRequest, Database.Ulaznice, UlazniceInsertRequest, UlazniceInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;
        public UlazniceService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private readonly static Random random = new Random();
        public static string GetVoucherNumber(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public override List<Model.Ulaznice> Get(UlazniceSearchRequest search)
        {
            var q = _context.Set<Database.Ulaznice>().AsQueryable();

            if (search?.KorisnikID.HasValue == true)
            {
                q = q.Where(s => s.Korisnik.KorisnikId == search.KorisnikID);
            }
            if (search?.Godina.HasValue == true)
            {
                q = q.Where(s => s.DatumKupnje.Year == search.Godina);
            }
            if (search?.UtakmicaID.HasValue == true)
            {
                q = q.Where(s => s.UtakmicaId == search.UtakmicaID);
            }
            var list = q.ToList().OrderByDescending(s => s.DatumKupnje);
            return _mapper.Map<List<Model.Ulaznice>>(list);

        }
        public override Model.Ulaznice Insert(UlazniceInsertRequest req)
        {
            Korisnici k = _context.Korisnici.FirstOrDefault(s => s.KorisnikId == req.KorisnikID);
            Korisnik korisnik = _mapper.Map<Korisnik>(k);
            Model.Utakmice u = _mapper.Map<Model.Utakmice>(_context.Utakmice.FirstOrDefault(s => s.UtakmicaId == req.UtakmicaID));
            Model.Sjedala a = _mapper.Map<Model.Sjedala>(_context.Sjedala.FirstOrDefault(s => s.SjedaloId == req.SjedaloID));
            string number = "Ime i prezime: " + korisnik.KorisnikPodaci + "---Utakmica: " + u.UtakmicaPodaci + "----Sjedalo/Sektor: " + a.Oznaka + "/" + a.Sektor + "---Datum kupnje: " + req.DatumKupnje.ToString() + "---Vrijeme kupnje:" + req.VrijemeKupnje.ToString() + "$" + GetVoucherNumber(8);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var bitmapBytes = BitmapToBytes(qrCodeImage);
            req.barcodeimg = bitmapBytes;

            return base.Insert(req);
        }
        public override Model.Ulaznice Update(int id, UlazniceInsertRequest req)
        {
            Korisnici k = _context.Korisnici.FirstOrDefault(s => s.KorisnikId == req.KorisnikID);
            Korisnik korisnik = _mapper.Map<Korisnik>(k);
            string number = korisnik.KorisnikPodaci + "$" + req.UtakmicaID + "$" + req.SjedaloID + "$" + req.DatumKupnje.ToString() + "$" + req.VrijemeKupnje.ToString() + "$" + GetVoucherNumber(8);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var bitmapBytes = BitmapToBytes(qrCodeImage);
            req.barcodeimg = bitmapBytes;

            return base.Update(id, req);
        }

    }
}
