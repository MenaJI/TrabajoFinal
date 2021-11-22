using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AniosController : ControllerBase
    {
        private IAniosService aniosService;

        public AniosController(IAniosService anioService) { aniosService = anioService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Anios>> GetAll()
        {
            return Ok(aniosService.Get());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Anios> GetById(int id)
        {
            Anios result = aniosService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Anios anio)
        {
            aniosService.Insert(anio);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Anios anio)
        {
            aniosService.Update(anio);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Anios anio)
        {
            aniosService.Delete(anio);

            return Ok();
        }
    }
}