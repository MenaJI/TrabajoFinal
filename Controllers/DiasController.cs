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
            return Ok(diasService.GetAll());
        }

        [HttpGet("GetDia/{id:int}")]
        public ActionResult<Dias> GetById(int id)
        {
            Dias result = diasService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Dias dia)
        {
            diasService.PostDias(dia);
            diasService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Dias dia)
        {
            diasService.PutDias(dia);
            diasService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Dias dia)
        {
            diasService.DeleteDias(dia);
            diasService.SaveChanges();

            return Ok();
        }
    }
}