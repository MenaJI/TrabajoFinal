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

        private ICarrerasService carrerasService;

        private IInscripcionCarreraService inscripcionCarreraService;

        public AlumnosController(IAlumnosServices alumnosServices_, ICarrerasService carrerasService_, IInscripcionCarreraService inscripcionCarreraService_)
        {

            alumnosServices = alumnosServices_;
            carrerasService = carrerasService_;
            inscripcionCarreraService = inscripcionCarreraService_;

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
            var alumno = alumnosServices.Get(a => a.NombreUsuario == UserName, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno != null)
            {
                var inscripciones = inscripcionCarreraService.Get(i => alumno.InscripcionCarreras.FirstOrDefault(x => x.Id == i.Id) != null, "");

                foreach (var inscripcion in inscripciones)
                {
                    inscripcion.Carrera = carrerasService.Get(c => c.Id == inscripcion.Fk_Carrera, "").FirstOrDefault();
                }

                alumno.InscripcionCarreras = inscripciones.ToList();
                return Ok(alumnosServices.MapearAlumnoModel(alumno));
            }

            return NotFound();
        }

        [HttpGet("AgregarIC")]
        public IActionResult AgregarIC(string UserName, string Carrera, string Estado)
        {
            var alumno = alumnosServices.Get(a => a.NombreUsuario == UserName, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            var carrera = carrerasService.Get(c => c.Descripcion == Carrera, "").FirstOrDefault();

            if (alumno != null && carrera != null)
            {
                alumno.InscripcionCarreras.Add(new InscripcionCarrera()
                {
                    Carrera = carrera,
                    Estado = Estado
                });
                alumnosServices.Update(alumno);
                return Ok(alumnosServices.MapearAlumnoModel(alumno));
            }

            return NotFound();
        }

        [HttpGet("AnularIC")]
        public IActionResult AnularIC(int id, string estado)
        {
            var result = inscripcionCarreraService.Get(i => i.Id == id, "").FirstOrDefault();

            if (result != null)
            {
                result.Estado = estado;
                inscripcionCarreraService.Update(result);
                return Ok();
            }

            return NotFound(new Response() { Status = "Error", Message = "No se han encontrado alumnos." });
        }

    };

}