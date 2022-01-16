using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.Models;
using System;
using System.Linq;

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
                var result = alumnosServices.Insert(alumno);

                if (result != null)
                    return Ok(new Response() { Status = "0001", Message = "Ya existe " });

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new Response() { Status = "Error", Message = ex.InnerException.Message });
            }
        }

        [HttpGet("GetUserAlumno")]
        public IActionResult GetUserAlumno(string UserName)
        {
            var result = alumnosServices.Get(a => a.NombreUsuario == UserName, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (result != null)
            {
                return Ok(alumnosServices.MapearAlumnoModel(result));
            }

            return NotFound();
        }
    };

}