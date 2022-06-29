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
        private ICondicionesService condicionesService;

        public InscripcionesMateriaController(IInscripcionesMateriaService InscripcionMateriaService_,
        ICarrerasService _carrerasService,
        IAniosService _aniosService,
        IAlumnosServices _alumnoService,
        ICursosServices _cursosService,
        IMateriasService _materiasService,
        ICondicionesService _condicionService)
        {
            InscripcionMateriaService = InscripcionMateriaService_;
            carrerasService = _carrerasService;
            aniosService = _aniosService;
            alumnosServices = _alumnoService;
            cursosServices = _cursosService;
            materiasService = _materiasService;
            condicionesService = _condicionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var inscripciones = InscripcionMateriaService.Get("Curso,Materias,Alumno,Condicion");
            var inscripcionesNoAnuladas = inscripciones.Where(x => x.Estado != "ANULADA");

            foreach (var inscripcion in inscripcionesNoAnuladas)
            {
                inscripcion.Materias.Carrera = carrerasService.GetByID(inscripcion.Materias.Fk_Carrera);
                inscripcion.Materias.Anio = aniosService.GetByID(inscripcion.Materias.Fk_Anio);
            }

            return Ok(inscripcionesNoAnuladas);
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

        [HttpGet("CambiarCondicionInscripcion")]
        public IActionResult CambiarCondicionInscripcion(int inscripcionId, string condicionDescrip)
        {
            var inscripcion = InscripcionMateriaService.GetByID(inscripcionId);
            var condicion = condicionesService.Get(x => x.Descrip == condicionDescrip, "").FirstOrDefault();
            if (inscripcion != null)
            {
                inscripcion.Condicion = condicion;
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

        [HttpGet("GetByFiltro")]
        public IActionResult GetByFiltro(string nombreApellido = "", string dni = "", string carrera = "", string condicion = "")
        {
            double alumnoDNI = 0;
            Alumnos alumno = null;
            Carreras _carrera = null;
            Condiciones _condicion = null;
            List<InscripcionesMateria> result = new List<InscripcionesMateria>();
            
            if (!string.IsNullOrEmpty(condicion))
                _condicion = condicionesService.Get(x => x.Descrip == condicion, "").FirstOrDefault();
            if (double.TryParse(dni, out var doubleDNI))
                alumnoDNI = doubleDNI;
            if (!string.IsNullOrEmpty(carrera))
                _carrera = carrerasService.Get(x => x.Descripcion == carrera, "").FirstOrDefault();

            if (string.IsNullOrEmpty(nombreApellido) &&
                string.IsNullOrEmpty(dni) &&
                string.IsNullOrEmpty(carrera) &&
                string.IsNullOrEmpty(condicion))
                return Ok(InscripcionMateriaService.Get(x => x.Fk_Condicion == 1,"Curso,Alumno,Condicion,Materias"));

            if (!string.IsNullOrEmpty(nombreApellido) || !string.IsNullOrEmpty(dni))
                alumno = alumnosServices.Get(x => (x.NombreCompleto.Contains(nombreApellido)
                || x.NombreCompleto == nombreApellido
                || x.NroDocumento == alumnoDNI),
                "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil")
                .FirstOrDefault();

            if (alumno != null)
            {
                result = InscripcionMateriaService
                    .Get(x => x.Alumno.Id == alumno.Id, "Curso,Alumno,Condicion,Materias")
                    .ToList();
            }

            if (_carrera != null && result.Any())
            {
                var listMateriasPorCarrera = materiasService.Get(x => x.Fk_Carrera == _carrera.Id,"").ToList();
                result = result.Where(x => listMateriasPorCarrera.Any( m => m.Id == x.Curso.Fk_Materia)).ToList();
            } else if (_carrera != null)
            {
                var listMateriasPorCarrera = materiasService.Get(x => x.Fk_Carrera == _carrera.Id,"").ToList();
                result.AddRange(InscripcionMateriaService.Get(x => listMateriasPorCarrera.Any( m => m.Id == x.Curso.Fk_Materia), "Curso,Alumno,Condicion,Materias"));
            }

            if (_condicion != null && result.Any())
                result = result.Where(ic => ic.Fk_Condicion == _condicion.Id).ToList();
            else if (_condicion != null)
                result.AddRange(InscripcionMateriaService.Get(ic => ic.Fk_Condicion == _condicion.Id, "Curso,Alumno,Condicion,Materias"));
            
            foreach(var im in result)
            {
                _carrera = carrerasService.Get(x => x.Id == im.Materias.Fk_Carrera,"").FirstOrDefault();
                im.CarreraNombre =  _carrera.Descripcion;
            }

            return Ok(result);
        }
    }
}