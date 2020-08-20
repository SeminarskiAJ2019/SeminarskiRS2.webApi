using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class TribineService : BaseCRUDService<Model.Tribine,TribineSearchRequest, Database.Tribine, TribineInsertRequest, TribineInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public TribineService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Tribine> Get(TribineSearchRequest search)
        {
            var q = _context.Set<Database.Tribine>().AsQueryable();

            if (!string.IsNullOrEmpty(search?.Naziv) && search?.StadionID.HasValue == true)
            {
                q = q.Where(s => (s.Naziv.Equals(search.Naziv)) && s.StadionId == search.StadionID);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Naziv))
                {
                    q = q.Where(s => (s.Naziv.StartsWith(search.Naziv)));
                }
                if (search?.StadionID.HasValue == true)
                {
                    q = q.Where(s => s.StadionId == search.StadionID);
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Tribine>>(list);

        }
    }
}
