using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private IGenerosService generosService;

        public GenerosController(IGenerosService generoService) { generosService = generoService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Generos>> GetAll()
        {
            return Ok(generosService.Get());
        }

        [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Generos> GetById(int id)
        {
            Generos result = generosService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Generos genero)
        {
            generosService.Insert(genero);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Generos genero)
        {
            generosService.Update(genero);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Generos genero)
        {
            generosService.Delete(genero);

            return Ok();
        }
    }
}