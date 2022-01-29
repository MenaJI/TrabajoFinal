using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;


namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class CarrerasController : ControllerBase
    {

        private ICarrerasService carrerasservices;

        public CarrerasController(ICarrerasService carrerasservice_)
        {

            carrerasservices = carrerasservice_;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = carrerasservices.Get();

            return Ok(result);
        }
                [HttpGet("GetGenero/{id:int}")]
        public ActionResult<Carreras> GetById(int id)
        {
            Carreras result = carrerasservices.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Carreras carrera)
        {
            carrerasservices.Insert(carrera);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Carreras carrera)
        {
            carrerasservices.Update(carrera);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Carreras carrera)
        {
            carrerasservices.Delete(carrera);

            return Ok();
        }
    };

}