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
            return Ok(nacionalidadesService.GetAll());
        }

        [HttpGet("GetNacionalidad/{id:int}")]
        public ActionResult<Nacionalidades> GetById(int id)
        {
            Nacionalidades result = nacionalidadesService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Nacionalidades nacionalidad)
        {
            nacionalidadesService.PostNacionalidades(nacionalidad);
            nacionalidadesService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Nacionalidades nacionalidad)
        {
            nacionalidadesService.PutNacionalidades(nacionalidad);
            nacionalidadesService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Nacionalidades nacionalidad)
        {
            nacionalidadesService.DeleteNacionalidades(nacionalidad);
            nacionalidadesService.SaveChanges();

            return Ok();
        }
    }
}