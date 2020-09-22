using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Services;

namespace SeminarskiRS2.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzaveGetController : ControllerBase
    {
        private readonly DrzaveService _service;

        public DrzaveGetController(DrzaveService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Drzave>> Get([FromQuery] DrzaveSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Model.Drzave Insert(DrzaveInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
