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
            return Ok(estadosCivilesServices.Get());
        }

        [HttpGet("GetEstadoCivil/{id:int}")]
        public ActionResult<Roles> GetById(int id)
        {
            EstadosCiviles result = estadosCivilesServices.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.Insert(estadoCivil);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.Update(estadoCivil);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(EstadosCiviles estadoCivil)
        {
            estadosCivilesServices.Delete(estadoCivil);

            return Ok();
        }
    }
}