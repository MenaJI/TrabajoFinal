using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormatosController : ControllerBase
    {
        private IFormatosService formatosService;

        public FormatosController(IFormatosService formatoService) { formatosService = formatoService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Formatos>> GetAll()
        {
            return Ok(formatosService.Get());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Formatos> GetById(int id)
        {
            Formatos result = formatosService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Formatos formato)
        {
            formatosService.Insert(formato);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Formatos formato)
        {
            formatosService.Update(formato);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Formatos formato)
        {
            formatosService.Delete(formato);

            return Ok();
        }
    }
}