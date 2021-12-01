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

        private IInscripcionCarreraService inscripcionCarreraService;

        public InscripcionController(IInscripcionCarreraService inscripcionCarreraService_)
        {

            inscripcionCarreraService = inscripcionCarreraService_;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = inscripcionCarreraService.Get();

            return Ok(result);
        }
    };

}