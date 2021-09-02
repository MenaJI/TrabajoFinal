using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;


namespace ApiREST.Controllers{
[ApiController]
[Route("api/{controller}")]

    public class InscripcionMateriaController : ControllerBase{

        private IInscripcionMateria InscripcionMateriaService;

        public InscripcionMateriaController(IInscripcionMateriaService InscripcionMateriaService_){

            InscripcionMateriaService = InscripcionMateriaService_;

        }
         
         [HttpGet("GetAll")]
         public IActionResult GetAll(){

             var result = InscripcionMateriaService.GetAll();

             return Ok(result);
         }
    };

}