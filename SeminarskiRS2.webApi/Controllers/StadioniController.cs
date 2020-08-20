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
    public class StadioniController : BaseCRUDController<Model.Stadioni, StadioniSearchRequest, StadioniInsertRequest, StadioniInsertRequest>
    {
        public StadioniController(ICRUDService<Model.Stadioni, StadioniSearchRequest, StadioniInsertRequest, StadioniInsertRequest> service) : base(service)
        {
        }
    }
}
