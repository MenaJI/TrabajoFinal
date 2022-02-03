using System.Collections.Generic;
using System.Linq;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocentesController : ControllerBase
    {
        private IDocentesServices docentesServices;

        public DocentesController(IDocentesServices anioService) { docentesServices = anioService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Docentes>> GetAll()
        {
            return Ok(docentesServices.Get("TipoDoc,Genero,Localidad,Nacionalidad,EstadoCivil"));
        }

        [HttpGet("GetDocentes/{id:int}")]
        public ActionResult<Docentes> GetById(int id)
        {
            Docentes result = docentesServices.Get(d => d.Id == id, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Docentes docente)
        {
            docentesServices.Insert(docente);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Docentes docente)
        {
            docentesServices.Update(docente);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Docentes docente)
        {
            docentesServices.Delete(docente);

            return Ok();
        }
    }
}