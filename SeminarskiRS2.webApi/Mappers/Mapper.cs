using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnici, Model.Korisnik>();
            //source pa destination
            //konverzija iz jednog smjera u drugi-reverse map
            CreateMap<Database.Korisnici, Model.Requests.KorisnikInsertRequest>().ReverseMap();
            CreateMap<Database.Drzave, Model.Drzave>();
            CreateMap<Database.Drzave, Model.Requests.DrzaveInsertRequest>().ReverseMap();
            CreateMap<Database.Gradovi, Model.Grad>();
            CreateMap<Database.Gradovi, Model.Requests.GradoviInsertRequest>().ReverseMap();
            CreateMap<Database.Timovi, Model.Timovi>();
            CreateMap<Database.Timovi, Model.Requests.TimoviInsertRequest>().ReverseMap();
            CreateMap<Database.Stadioni, Model.Stadioni>();
            CreateMap<Database.Stadioni, Model.Requests.StadioniInsertRequest>().ReverseMap();
            CreateMap<Database.Tribine, Model.Tribine>();
            CreateMap<Database.Tribine, Model.Requests.TribineInsertRequest>().ReverseMap();
            CreateMap<Database.Sektori, Model.Sektori>();
            CreateMap<Database.Sektori, Model.Requests.SektoriInsertRequest>().ReverseMap();
            CreateMap<Database.Preporuke, Model.Preporuke>();
            CreateMap<Database.Preporuke, Model.Requests.PreporukaInsertRequest>().ReverseMap();
            CreateMap<Database.Uplate, Model.Uplate>();
            CreateMap<Database.Uplate, Model.Uplate>()
                .ForMember(s => s.UplataPodaci, a => a.MapFrom(b => new Database._170120Context()
                .Ulaznice.Include(s => s.Utakmica.DomaciTim).Include(s => s.Utakmica.GostujuciTim).Include(s => s.Korisnik).FirstOrDefault(s => s.UlaznicaId == b.UlaznicaId).UlaznicaPodaci))
                .ForMember(s => s.Iznos, a => a.MapFrom(b => new Database._170120Context().Uplate.FirstOrDefault(s => s.UplataId == b.UplataId).Iznos / 100));

            CreateMap<Database.Uplate, Model.Requests.UplateInsertRequest>().ReverseMap();


            CreateMap<Database.Ulaznice, Model.Ulaznice>();
            CreateMap<Database.Ulaznice, Model.Requests.UlazniceInsertRequest>().ReverseMap();

            CreateMap<Database.Lige, Model.Lige>();
            CreateMap<Database.Lige, Model.Requests.LigaInsertRequest>().ReverseMap();
            CreateMap<Database.Sjedala, Model.Sjedala>();
            CreateMap<Database.Sjedala, Model.Requests.SjedalaInsertRequest>().ReverseMap();
            CreateMap<Database.Utakmice, Model.Utakmice>();
            CreateMap<Database.Utakmice, Model.Requests.UtakmiceInsertRequest>().ReverseMap();
            CreateMap<Model.Requests.UtakmiceInsertRequest, Database.Utakmice>()
                .ForMember(s => s.Dateonly, a => a.MapFrom(s => s.DatumOdigravanja.Date));

            CreateMap<Database.Korisnici, Model.Korisnik>()
                .ForMember(s => s.Naziv, a =>
                a.MapFrom(b => new Database._170120Context().Gradovi.Find(b.GradId).Naziv));

            CreateMap<Database.Gradovi, Model.Grad>()
                .ForMember(s => s.Drzava, a =>
                a.MapFrom(b => new Database._170120Context().Drzave.Find(b.DrzavaId).Naziv));

            CreateMap<Database.Sjedala, Model.Sjedala>()
                .ForMember(s => s.Sektor, a =>
                a.MapFrom(b => new Database._170120Context().Sektori.Find(b.SektorId).Naziv));

            CreateMap<Database.Stadioni, Model.Stadioni>()
              .ForMember(s => s.Grad, a =>
              a.MapFrom(b => new Database._170120Context().Gradovi.Find(b.GradId).Naziv));


            CreateMap<Database.Timovi, Model.Timovi>()
             .ForMember(s => s.Liga, a =>
             a.MapFrom(b => new Database._170120Context().Lige.Find(b.LigaId).Naziv))
             .ForMember(s => s.Stadion, a =>
              a.MapFrom(b => new Database._170120Context().Stadioni.Find(b.StadionId).Naziv));
            CreateMap<Database.Lige, Model.Lige>()
         .ForMember(s => s.Drzava, a =>
         a.MapFrom(b => new Database._170120Context().Drzave.Find(b.DrzavaId).Naziv));

            CreateMap<Database.Tribine, Model.Tribine>()
          .ForMember(s => s.Stadion, a =>
          a.MapFrom(b => new Database._170120Context().Stadioni.Find(b.StadionId).Naziv));



            CreateMap<Database.Utakmice, Model.Utakmice>()
            .ForMember(s => s.stadion, a =>
            a.MapFrom(b => new Database._170120Context().Stadioni.Find(b.StadionId).Naziv))
            .ForMember(s => s.GostujuciTim, a =>
            a.MapFrom(b => new Database._170120Context().Timovi.Find(b.GostujuciTimId).Naziv))
            .ForMember(s => s.DomaciTim, a =>
              a.MapFrom(b => new Database._170120Context().Timovi.Find(b.DomaciTimId).Naziv))
            .ForMember(s => s.Liga, a =>
               a.MapFrom(b => new Database._170120Context().Lige.Find(b.LigaId).Naziv));




            CreateMap<Database.Ulaznice, Model.Ulaznice>()
               .ForMember(s => s.Oznaka, a =>
               a.MapFrom(b => new Database._170120Context().Sjedala.Find(b.SjedaloId).Oznaka))
               .ForMember(s => s.utakmica, a =>
                a.MapFrom(b => new Database._170120Context().Utakmice
                .Include(s => s.DomaciTim).Include(s => s.GostujuciTim)
                .FirstOrDefault(s => s.UtakmicaId == b.UtakmicaId).DomaciTim.Naziv))

               .ForMember(s => s.korisnik, a =>
                a.MapFrom(b => new Database._170120Context().Korisnici.Find(b.KorisnikId).Korisnik))

               .ForMember(s => s.sektor, a =>
                  a.MapFrom(b => new Database._170120Context().Sjedala.Include(s => s.Sektor).FirstOrDefault(s => s.SjedaloId
                      == b.SjedaloId).Sektor.Naziv));



            CreateMap<Database.Sektori, Model.Sektori>()
                .ForMember(s => s.Cijena, a =>
                a.MapFrom(b => new Database._170120Context().Tribine
                .FirstOrDefault(s => s.TribinaId == b.TribinaId).Cijena))
                .ForMember(s => s.Tribina, a =>
                   a.MapFrom(b => new Database._170120Context().Tribine
                   .FirstOrDefault(s => s.TribinaId == b.TribinaId).Naziv));

        }
    }
}
