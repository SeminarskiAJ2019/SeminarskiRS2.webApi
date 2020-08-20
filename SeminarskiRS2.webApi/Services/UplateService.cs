using AutoMapper;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class UplateService : BaseCRUDService<Model.Uplate, UplateSearchRequest, Database.Uplate, UplateInsertRequest, UplateInsertRequest>
    {
        private readonly _170120Context _context;
        private readonly IMapper _mapper;

        public UplateService(_170120Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<Model.Uplate> Get(UplateSearchRequest search)
        {
            var q = _context.Set<Database.Uplate>().AsQueryable();

            if (search?.UtakmicaID.HasValue == true)
            {
                int i = (int)search.UtakmicaID;
                List<Model.Utakmice> lista = _mapper.Map<List<Model.Utakmice>>(_context.Set<Database.Utakmice>().ToList());

                Model.Utakmice utakmica = null;
                foreach (var u in lista)
                {
                    if (u.UtakmicaID == search.UtakmicaID)
                        utakmica = u;
                }

                var id = utakmica.UtakmicaID;
                q = q.Where(s => s.Ulaznica.UtakmicaId == id);
            }

            var list = q.ToList();
            return _mapper.Map<List<Model.Uplate>>(list);
        }
    }
}
