using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosCivilesController : ControllerBase
    {
        private IEstadosCivilesService estadosCivilesServices;

        public EstadosCivilesController(IEstadosCivilesService estadoCivilServices) { estadosCivilesServices = estadoCivilServices; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Roles>> GetAll()
        {
            return Ok(estadosCivilesServices.GetAll());
        }

        [HttpGet("GetEstadoCivil/{id:int}")]
        public ActionResult<Roles> GetById(int id)
        {
            EstadosCiviles result = estadosCivilesServices.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.PostEstadosCiviles(estadoCivil);
            estadosCivilesServices.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.PutEstadosCiviles(estadoCivil);
            estadosCivilesServices.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.DeleteEstadosCiviles(estadoCivil);
            estadosCivilesServices.SaveChanges();

            return Ok();
        }
    }
}