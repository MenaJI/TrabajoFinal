using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegimenesController : ControllerBase
    {
        private IRegimenesService regimenesService;

        public RegimenesController(IRegimenesService regimenService) { regimenesService = regimenService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Regimenes>> GetAll()
        {
            return Ok(regimenesService.Get());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Regimenes> GetById(int id)
        {
            Regimenes result = regimenesService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Regimenes regimen)
        {
            regimenesService.Insert(regimen);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Regimenes regimen)
        {
            regimenesService.Update(regimen);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Regimenes regimen)
        {
            regimenesService.Delete(regimen);

            return Ok();
        }
    }
}