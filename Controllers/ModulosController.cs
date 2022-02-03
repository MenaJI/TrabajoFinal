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
            modulosService.Insert(modulo);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Modulos modulo)
        {
            modulosService.Update(modulo);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Modulos modulo)
        {
            modulosService.Delete(modulo);

            return Ok();
        }
    }
}