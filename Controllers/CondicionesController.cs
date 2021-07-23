using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondicionesController : ControllerBase
    {
        private ICondicionesService condicionesService;

        public CondicionesController(ICondicionesService condicionService) { condicionesService = condicionService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Condiciones>> GetAll()
        {
            return Ok(condicionesService.GetAll());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Condiciones> GetById(int id)
        {
            Condiciones result = condicionesService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Condiciones condicion)
        {
            condicionesService.PostCondiciones(condicion);
            condicionesService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Condiciones condicion)
        {
            condicionesService.PutCondiciones(condicion);
            condicionesService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Condiciones condicion)
        {
            condicionesService.DeleteCondiciones(condicion);
            condicionesService.SaveChanges();

            return Ok();
        }
    }
}