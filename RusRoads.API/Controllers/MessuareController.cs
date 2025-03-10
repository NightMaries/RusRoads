using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RusRoads.API.DTO;

namespace RusRoads.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MessuareController(RusRoadsContext db, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MessuareDto>> getAll (){
            
            var mes = db.Messuare.ToList();
            var mesDto = mapper.Map<IEnumerable<MessuareDto>>(mes);
            return Ok(mesDto);
        }
    }
}