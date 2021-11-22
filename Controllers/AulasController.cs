using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AulasController : ControllerBase
    {
        private IAulasService aulasService;

        public AulasController(IAulasService aulaService) { aulasService = aulaService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Aulas>> GetAll()
        {
            return Ok(aulasService.Get());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Aulas> GetById(int id)
        {
            Aulas result = aulasService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Aulas aula)
        {
            aulasService.Insert(aula);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Aulas aula)
        {
            aulasService.Update(aula);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Aulas aula)
        {
            aulasService.Delete(aula);

            return Ok();
        }
    }
}