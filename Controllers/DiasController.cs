using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiasController : ControllerBase
    {
        private IDiasService diasService;

        public DiasController(IDiasService diaService) { diasService = diaService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Dias>> GetAll()
        {
            return Ok(diasService.Get());
        }

        [HttpGet("GetDia/{id:int}")]
        public ActionResult<Dias> GetById(int id)
        {
            Dias result = diasService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Dias dia)
        {
            diasService.Insert(dia);


            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Dias dia)
        {
            diasService.Update(dia);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Dias dia)
        {
            diasService.Delete(dia);

            return Ok();
        }
    }
}