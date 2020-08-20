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
    
    public class GradoviController : BaseCRUDController<Model.Grad, GradoviSearchRequest,GradoviInsertRequest,GradoviInsertRequest>
    {
        public GradoviController(ICRUDService<Grad, GradoviSearchRequest,GradoviInsertRequest,GradoviInsertRequest> service) : base(service)
        {
        }
    }
}
