using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using ApiREST.Models;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class InscripcionesMateriaController : ControllerBase
    {
        private IInscripcionesMateriaService InscripcionMateriaService;
        private ICarrerasService carrerasService;
        private IAniosService aniosService;
        private IAlumnosServices alumnosServices;
        private ICursosServices cursosServices;
        private IMateriasService materiasService;

        public InscripcionesMateriaController(IInscripcionesMateriaService InscripcionMateriaService_,
        ICarrerasService _carrerasService,
        IAniosService _aniosService,
        IAlumnosServices _alumnoService,
        ICursosServices _cursosService,
        IMateriasService _materiasService)
        {
            InscripcionMateriaService = InscripcionMateriaService_;
            carrerasService = _carrerasService;
            aniosService = _aniosService;
            alumnosServices = _alumnoService;
            cursosServices = _cursosService;
            materiasService = _materiasService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var inscripciones = InscripcionMateriaService.Get("Curso,Materias,Alumno,Condicion");

            foreach (var inscripcion in inscripciones)
            {
                inscripcion.Materias.Carrera = carrerasService.GetByID(inscripcion.Materias.Fk_Carrera);
                inscripcion.Materias.Anio = aniosService.GetByID(inscripcion.Materias.Fk_Anio);
            }

            return Ok(inscripciones);
        }

        [HttpGet("CambiarEstadoInscripcion")]
        public IActionResult CambiarEstadoInscripcion(int inscripcionId, string estado)
        {
            var inscripcion = InscripcionMateriaService.GetByID(inscripcionId);
            if (inscripcion != null)
            {
                inscripcion.Estado = estado;
            }

            InscripcionMateriaService.Update(inscripcion);

            return Ok();
        }

        [HttpGet("AddInscripcion")]
        public IActionResult AddItem(string username, int id, string estado)
        {
            var curso = cursosServices.GetByID(id);
            var inscripcion = new InscripcionesMateria()
            {
                Fecha = DateTime.Now,
                Activo = true,
                Fk_Alumno = alumnosServices.Get(a => a.NombreUsuario == username, "").FirstOrDefault().Id,
                Fk_Curso = id,
                Fk_Condicion = curso.Fk_CondicionCurso,
                Materias = materiasService.GetByID(curso.Fk_Materia),
                Estado = estado

            };

            InscripcionMateriaService.Insert(inscripcion);

            return Ok();
        }
    }
}