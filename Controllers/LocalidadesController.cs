using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalidadesController : ControllerBase
    {
        private ILocalidadesService localidadesService;

        public LocalidadesController(ILocalidadesService localidadService) { localidadesService = localidadService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Localidades>> GetAll()
        {
            return Ok(localidadesService.Get());
        }

        [HttpGet("GetLocalidad/{id:int}")]
        public ActionResult<Localidades> GetById(int id)
        {
            Localidades result = localidadesService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Localidades localidad)
        {
            localidadesService.Insert(localidad);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Localidades localidad)
        {
            localidadesService.Insert(localidad);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Localidades localidad)
        {
            localidadesService.Delete(localidad);

            return Ok();
        }
    }
}