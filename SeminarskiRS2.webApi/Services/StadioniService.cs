using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class StadioniService : BaseCRUDService<Model.Stadioni, StadioniSearchRequest, Database.Stadioni, StadioniInsertRequest, StadioniInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public StadioniService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public override List<Model.Stadioni> Get(StadioniSearchRequest search)
        {
            var q = _context.Set<Database.Stadioni>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv) && search?.GradID.HasValue == true)
            {
                q = q.Where(s => s.Naziv.Equals(search.Naziv) && s.GradId == search.GradID);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search?.Naziv))
                {
                    q = q.Where(s => s.Naziv.StartsWith(search.Naziv));
                }
                if (search?.GradID.HasValue == true)
                {
                    q = q.Where(s => (s.GradId == search.GradID));
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Stadioni>>(list);

        }
    }
}
