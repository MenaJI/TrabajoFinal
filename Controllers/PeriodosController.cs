using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodosController : ControllerBase
    {
        private IPeriodosService periodosService;

        public PeriodosController(IPeriodosService _periodosService) { periodosService = _periodosService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Periodos>> GetAll()
        {
            return Ok(periodosService.Get());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Periodos> GetById(int id)
        {
            Periodos periodo = periodosService.GetByID(id);
            if (periodo != null)
            {
                return Ok(periodo);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Periodos periodo)
        {
            periodosService.Insert(periodo);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Periodos periodo)
        {
            periodosService.Update(periodo);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Periodos periodo)
        {
            periodosService.Delete(periodo);

            return Ok();
        }
    }
}