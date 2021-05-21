using Autos_Bewertung_App.Models;
using Autos_Bewertung_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autos_Bewertung_App.Controllers
{
    [Route("autos")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        public AutosController(JsonDateiAutoService jsonDateiAutoService)
        {
            this.AutoService = jsonDateiAutoService;
        }
        public JsonDateiAutoService AutoService { get; }

        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return AutoService.GetAutos();
        }

        [Route("rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] int id, [FromQuery] int rating)
        {
            AutoService.AddRating(id, rating);
            return Ok();
        }
    }
}
