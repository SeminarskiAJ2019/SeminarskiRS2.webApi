using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class PreporukeService : BaseCRUDService<Model.Preporuke, PreporukaSearchRequest, Database.Preporuke, PreporukaInsertRequest, PreporukaInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public PreporukeService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Preporuke> Get(PreporukaSearchRequest search)
        {
            var q = _context.Set<Database.Preporuke>().AsQueryable();

            if (search?.KorisnikID.HasValue == true)
            {
                q = q.Where(s => s.KorisnikId == search.KorisnikID).OrderByDescending(s => s.BrojKupljenihUlaznica);
            }
            if (search?.KorisnikID.HasValue == true && search?.PrviTimID.HasValue == true && search?.DrugiTimID.HasValue == true)
            {
                q = q.Where(s => s.KorisnikId == search.KorisnikID && (s.TimId == search.PrviTimID || s.TimId == search.DrugiTimID));
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Preporuke>>(list);

        }
    }
}
