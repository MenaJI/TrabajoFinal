using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamposController : ControllerBase
    {
        private ICamposService camposService;

        public CamposController(ICamposService campoService) { camposService = campoService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Campos>> GetAll()
        {
            return Ok(camposService.Get());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Campos> GetById(int id)
        {
            Campos result = camposService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Campos campo)
        {
            camposService.Insert(campo);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Campos campo)
        {
            camposService.Update(campo);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Campos campo)
        {
            camposService.Delete(campo);

            return Ok();
        }
    }
}