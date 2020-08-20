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
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciInsertController : ControllerBase
    {
        private readonly IKorisniciService _service;

        public KorisniciInsertController(IKorisniciService service)
        {
            _service = service;
        }
        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpGet]
        public List<Model.Korisnik> Get([FromQuery] KorisnikSearchRequest request)
        {
            return _service.Get(request);
        }
    }
}
