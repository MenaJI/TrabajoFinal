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
            return Ok(condicionesService.Get());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Condiciones> GetById(int id)
        {
            Condiciones result = condicionesService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Condiciones condicion)
        {
            condicionesService.Insert(condicion);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Condiciones condicion)
        {
            condicionesService.Update(condicion);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Condiciones condicion)
        {
            condicionesService.Delete(condicion);

            return Ok();
        }
    }
}