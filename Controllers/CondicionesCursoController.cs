using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondicionesCursoController : ControllerBase
    {
        private ICondicionesCursoService condicionesCursoService;

        public CondicionesCursoController(ICondicionesCursoService condicionCursoService) { condicionesCursoService = condicionCursoService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<CondicionesCurso>> GetAll()
        {
            return Ok(condicionesCursoService.Get());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<CondicionesCurso> GetById(int id)
        {
            CondicionesCurso result = condicionesCursoService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] CondicionesCurso condicionCurso)
        {
            condicionesCursoService.Insert(condicionCurso);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(CondicionesCurso condicionCurso)
        {
            condicionesCursoService.Insert(condicionCurso);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(CondicionesCurso condicionCurso)
        {
            condicionesCursoService.Delete(condicionCurso);

            return Ok();
        }
    }
}