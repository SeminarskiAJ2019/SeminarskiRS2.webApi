using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SeminarskiRS2.webApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Services
{
    public class BaseService<TModel, TSearch,TDatabase> : IService<TModel, TSearch> where TDatabase: class
    {
        protected readonly _170120Context _context;
        protected readonly IMapper _mapper;
        private IMapper mapper;
        private _170120Context context;

        public BaseService(_170120Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseService(IMapper mapper, _170120Context context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public virtual List<TModel> Get(TSearch search)
        {
            var list = _context.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity);
        }
    }
}
