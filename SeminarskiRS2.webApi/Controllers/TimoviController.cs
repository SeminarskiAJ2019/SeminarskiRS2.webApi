using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Services;

namespace SeminarskiRS2.webApi.Controllers
{
    public class TimoviController : BaseCRUDController<Model.Timovi, TimoviSearchRequest, TimoviInsertRequest, TimoviInsertRequest>
    {
        public TimoviController(ICRUDService<Model.Timovi, TimoviSearchRequest, TimoviInsertRequest, TimoviInsertRequest> service) : base(service)
        {
        }
    }
}
