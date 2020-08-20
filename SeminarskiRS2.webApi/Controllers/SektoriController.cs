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
  
    public class SektoriController : BaseCRUDController<Model.Sektori, SektoriSearchRequest, SektoriInsertRequest, SektoriInsertRequest>
    {
        public SektoriController(ICRUDService<Model.Sektori, SektoriSearchRequest, SektoriInsertRequest, SektoriInsertRequest> service) : base(service)
        {
        }
    }
}
