using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;


namespace ApiREST.Controllers{
[ApiController]
[Route("api/{controller}")]

    public class CarrerasController : ControllerBase{

        private ICarrerasService carrerasservices;

        public CarrerasController(ICarrerasService carrerasservice_){

            carrerasservices = carrerasservice_;

        }
         
         [HttpGet("GetAll")]
         public IActionResult GetAll(){

             var result = carrerasservices.GetAll();

             return Ok(result);
         }
    };

}