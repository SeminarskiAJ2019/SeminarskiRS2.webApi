using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class DrzaveService : BaseCRUDService<Model.Drzave, DrzaveSearchRequest, Database.Drzave, DrzaveInsertRequest, DrzaveInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public DrzaveService(IMapper mapper, _170120Context context) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public override List<Model.Drzave> Get(DrzaveSearchRequest search)
        {
            var q = _context.Set<Database.Drzave>().AsQueryable();

            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                q = q.Where(s => s.Naziv.StartsWith(search.Naziv));
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Drzave>>(list);

        }
    }
}
