using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisesController : ControllerBase
    {
        private IPaisesService paisesService;

        public PaisesController(IPaisesService _paisesService) { paisesService = _paisesService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Paises>> GetAll()
        {
            return Ok(paisesService.Get());
        }

        [HttpGet("GetPais/{id:int}")]
        public ActionResult<Paises> GetById(int id)
        {
            Paises result = paisesService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Paises aula)
        {
            paisesService.Insert(aula);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Paises aula)
        {
            paisesService.Update(aula);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Paises aula)
        {
            paisesService.Delete(aula);

            return Ok();
        }
    }
}