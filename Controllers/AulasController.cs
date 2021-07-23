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
            return Ok(aulasService.GetAll());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Aulas> GetById(int id)
        {
            Aulas result = aulasService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Aulas aula)
        {
            aulasService.PostAulas(aula);
            aulasService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Aulas aula)
        {
            aulasService.PutAulas(aula);
            aulasService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Aulas aula)
        {
            aulasService.DeleteAulas(aula);
            aulasService.SaveChanges();

            return Ok();
        }
    }
}