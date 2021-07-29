using System.Collections.Generic;
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
            return Ok(modulosService.GetAll());
        }

        [HttpGet("GetModulo/{id:int}")]
        public ActionResult<Modulos> GetById(int id)
        {
            Modulos result = modulosService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Modulos modulo)
        {
            modulosService.PostModulos(modulo);
            modulosService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Modulos modulo)
        {
            modulosService.PutModulos(modulo);
            modulosService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Modulos modulo)
        {
            modulosService.DeleteModulos(modulo);
            modulosService.SaveChanges();

            return Ok();
        }
    }
}