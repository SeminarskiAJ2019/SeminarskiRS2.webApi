using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Database;
using SeminarskiRS2.webApi.Services;

namespace SeminarskiRS2.webApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Korisnik>> Get([FromQuery]KorisnikSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.Korisnik Update(int id, KorisnikInsertRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpGet("{id}")]
        public Model.Korisnik GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
