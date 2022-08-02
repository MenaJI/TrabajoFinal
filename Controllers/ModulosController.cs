using System.Collections.Generic;
using System.Linq;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulosController : ControllerBase
    {
        private IModulosService modulosService;

        public ModulosController(IModulosService moduloService) { modulosService = moduloService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Modulos>> GetAll()
        {
            return Ok(modulosService.Get("Dia,Horario"));
        }

        [HttpGet("GetModulo/{id:int}")]
        public ActionResult<Modulos> GetById(int id)
        {
            Modulos result = modulosService.Get(m => m.Id == id, "Dia,Horario").FirstOrDefault();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Modulos modulo)
        {
            var result = modulosService.Insert(modulo);
            result = modulosService.Get(x => x.Id == result.Id, "Dia,Horario").FirstOrDefault();
            return Ok(result);
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Modulos modulo)
        {
            modulosService.Update(modulo);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Modulos modulo)
        {
            modulosService.Delete(modulo);

            return Ok();
        }
    }
}