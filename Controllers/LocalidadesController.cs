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
            return Ok(localidadesService.GetAll());
        }

        [HttpGet("GetLocalidad/{id:int}")]
        public ActionResult<Localidades> GetById(int id)
        {
            Localidades result = localidadesService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Localidades localidad)
        {
            localidadesService.PostLocalidades(localidad);
            localidadesService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Localidades localidad)
        {
            localidadesService.PutLocalidades(localidad);
            localidadesService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Localidades localidad)
        {
            localidadesService.DeleteLocalidades(localidad);
            localidadesService.SaveChanges();

            return Ok();
        }
    }
}