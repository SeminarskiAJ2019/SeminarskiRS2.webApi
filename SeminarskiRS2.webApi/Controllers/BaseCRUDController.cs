using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS2.webApi.Services;

namespace SeminarskiRS2.webApi.Controllers
{
    public class BaseCRUDController<TModel,TSearch,TInsert,TUpdate> : BaseController<TModel,TSearch>
    {
        private readonly ICRUDService<TModel, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<TModel,TSearch,TInsert,TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, [FromBody]TUpdate request)
        {
            return _service.Update(id,request);
        }
    }
}
