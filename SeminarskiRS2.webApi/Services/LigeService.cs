using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class LigeService : BaseCRUDService<Model.Lige, Model.Requests.LigaSearchRequest, Database.Lige, LigaInsertRequest, LigaInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;
        public LigeService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Lige> Get(LigaSearchRequest search)
        {
            var q = _context.Set<Database.Lige>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Naziv) && search?.DrzavaID.HasValue == true)
            {
                q = q.Where(s => s.Naziv.Equals(search.Naziv) && s.DrzavaId == search.DrzavaID);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Naziv))
                {
                    q = q.Where(s => s.Naziv.StartsWith(search.Naziv));
                }
                if (search?.DrzavaID.HasValue == true)
                {
                    q = q.Where(s => s.Drzava.DrzavaId == search.DrzavaID);
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Lige>>(list);

        }
    }
}
