using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class SektoriService : BaseCRUDService<Model.Sektori, SektoriSearchRequest, Database.Sektori, SektoriInsertRequest, SektoriInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;
        public SektoriService(_170120Context context,IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public override List<Model.Sektori> Get(SektoriSearchRequest search)
        {
            var q = _context.Set<Database.Sektori>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv) && search.TribinaID.HasValue)
            {
                q = q.Where(s => s.Naziv == search.Naziv && s.TribinaId == search.TribinaID);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search?.Naziv))
                {
                    q = q.Where(s => s.Naziv == search.Naziv);
                }
                if (search.TribinaID.HasValue)
                {
                    q = q.Where(s => (s.TribinaId == search.TribinaID));
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Sektori>>(list);

        }
    }
}
