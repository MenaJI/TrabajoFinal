using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;


namespace ApiREST.Controllers{
[ApiController]
[Route("api/{controller}")]

    public class AlumnosController : ControllerBase{

        private IAlumnosServices alumnosServices;

        public AlumnosController(IAlumnosServices alumnosServices_){

            alumnosServices = alumnosServices_;

        }
         
         [HttpGet("GetAll")]
         public IActionResult GetAll(){

             var result = alumnosServices.GetAll();

             return Ok(result);
         }
    };

}