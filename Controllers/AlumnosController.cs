using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.Models;
using System;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class AlumnosController : ControllerBase
    {

        private IAlumnosServices alumnosServices;

        public AlumnosController(IAlumnosServices alumnosServices_)
        {

            alumnosServices = alumnosServices_;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = alumnosServices.GetAll();

            if (result != null)
                return Ok(result);

            return NotFound(new Response() { Status = "Error", Message = "No se han encontrado alumnos." });
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(AlumnosModel alumno)
        {
            try
            {
                alumnosServices.Insert(alumno);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new Response() { Status = "Error", Message = ex.InnerException.Message });
            }
        }

        [HttpPost("GetUserAlumno")]
        public IActionResult GetUserAlumno(string UserName)
        {
            var result = alumnosServices.GetAsNoTracking(a => a.NombreUsuario == UserName);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    };

}