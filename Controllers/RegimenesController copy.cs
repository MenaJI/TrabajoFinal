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
            return Ok(formatosService.GetAll());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Formatos> GetById(int id)
        {
            Formatos result = formatosService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Formatos formato)
        {
            formatosService.PostFormatos(formato);
            formatosService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Formatos formato)
        {
            formatosService.PutFormatos(formato);
            formatosService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Formatos formato)
        {
            formatosService.DeleteFormatos(formato);
            formatosService.SaveChanges();

            return Ok();
        }
    }
}