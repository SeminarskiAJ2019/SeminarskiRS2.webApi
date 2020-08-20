using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class SjedalaService : BaseCRUDService<Model.Sjedala, SjedalaSearchRequest, Database.Sjedala, SjedalaInsertRequest, SjedalaInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;
        public SjedalaService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Sjedala> Get(SjedalaSearchRequest search)
        {
            var q = _context.Set<Database.Sjedala>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Oznaka) && search?.SektorID.HasValue == true)
            {
                q = q.Where(s => (s.Oznaka.Equals(search.Oznaka)) && s.SektorId == search.SektorID);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Oznaka))
                {
                    q = q.Where(s => (s.Oznaka.StartsWith(search.Oznaka)));
                }
                if (search?.SektorID.HasValue == true)
                {
                    q = q.Where(s => s.SektorId == search.SektorID);
                }
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Sjedala>>(list);

        }
    }
}
