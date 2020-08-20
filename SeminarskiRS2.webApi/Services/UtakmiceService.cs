using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class UtakmiceService : BaseCRUDService<Model.Utakmice, UtakmiceSearchRequest, Database.Utakmice, UtakmiceInsertRequest, UtakmiceInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public UtakmiceService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Utakmice> Get(UtakmiceSearchRequest search)
        {
            var q = _context.Set<Database.Utakmice>().AsQueryable();
            if (!search.sveUtakmice)
                q = q.Where(s => s.DatumOdigravanja.Date >= DateTime.Now.Date);

            if (search?.LigaID.HasValue == true)
            {
                q = q.Where(s => s.LigaId == search.LigaID);
            }
            if (search?.StadionID.HasValue == true)
            {
                q = q.Where(s => s.StadionId == search.StadionID);
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Utakmice>>(list);

        }
    }
}
