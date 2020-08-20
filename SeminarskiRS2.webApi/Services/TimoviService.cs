using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class TimoviService : BaseCRUDService<Model.Timovi, TimoviSearchRequest, Database.Timovi, TimoviInsertRequest, TimoviInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public TimoviService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public override List<Model.Timovi> Get(TimoviSearchRequest search)
        {
            var q = _context.Set<Database.Timovi>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv) && search?.LigaID.HasValue == true)
            {
                q = q.Where(s => s.Naziv.Equals(search.Naziv) && s.LigaId == search.LigaID);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search?.Naziv))
                {
                    q = q.Where(s => s.Naziv.StartsWith(search.Naziv));
                }
                if (search?.LigaID.HasValue == true)
                {
                    q = q.Where(s => s.LigaId == search.LigaID);
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Timovi>>(list);

        }
    }
}
