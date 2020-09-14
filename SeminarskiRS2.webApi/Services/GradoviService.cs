using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class GradoviService : BaseCRUDService<Model.Grad, Model.Requests.GradoviSearchRequest, Database.Gradovi,GradoviInsertRequest,GradoviInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public GradoviService(IMapper mapper, _170120Context context) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Grad> Get(GradoviSearchRequest search)
        {
            var q = _context.Set<Database.Gradovi>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                q = q.Where(s => s.Naziv.StartsWith(search.Naziv));
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Grad>>(list);
          
            
        }
    }
}
