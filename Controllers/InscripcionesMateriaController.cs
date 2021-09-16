using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class InscripcionesMateriaController : ControllerBase
    {
        private IInscripcionesMateriaService InscripcionMateriaService;

        public InscripcionesMateriaController(IInscripcionesMateriaService InscripcionMateriaService_)
        {
            InscripcionMateriaService = InscripcionMateriaService_;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(InscripcionMateriaService.GetAll());
        }
    }
}