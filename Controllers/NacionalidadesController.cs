using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NacionalidadesController : ControllerBase
    {
        private INacionalidadesService nacionalidadesService;

        public NacionalidadesController(INacionalidadesService nacionalidadService) { nacionalidadesService = nacionalidadService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Nacionalidades>> GetAll()
        {
            return Ok(nacionalidadesService.Get());
        }

        [HttpGet("GetNacionalidad/{id:int}")]
        public ActionResult<Nacionalidades> GetById(int id)
        {
            Nacionalidades result = nacionalidadesService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Nacionalidades nacionalidad)
        {
            nacionalidadesService.Insert(nacionalidad);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Nacionalidades nacionalidad)
        {
            nacionalidadesService.Update(nacionalidad);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Nacionalidades nacionalidad)
        {
            nacionalidadesService.Delete(nacionalidad);

            return Ok();
        }
    }
}