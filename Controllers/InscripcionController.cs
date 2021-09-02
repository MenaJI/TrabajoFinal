using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;


namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class InscripcionController : ControllerBase
    {

        private IInscripcionService inscripcionservices;

        public InscripcionController(IInscripcionService inscripcionservice_)
        {

            inscripcionservices = inscripcionservice_;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = inscripcionservices.GetAll();

            return Ok(result);
        }
    };

}