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
        private IInscripcionCarreraService inscripcionCarreraService;

        public InscripcionesMateriaController(IInscripcionesMateriaService InscripcionMateriaService_,
        ICarrerasService _carrerasService,
        IAniosService _aniosService,
        IAlumnosServices _alumnoService,
        ICursosServices _cursosService,
        IMateriasService _materiasService,
        IInscripcionCarreraService _inscripcionCarrera)
        {
            InscripcionMateriaService = InscripcionMateriaService_;
            carrerasService = _carrerasService;
            aniosService = _aniosService;
            alumnosServices = _alumnoService;
            cursosServices = _cursosService;
            materiasService = _materiasService;
            inscripcionCarreraService = _inscripcionCarrera;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var inscripciones = InscripcionMateriaService.Get("Curso,Materias,Alumno");
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

        [HttpPost("AddInscripcion")]
        public IActionResult AddItem([FromBody] InscripcionesMateriasModel model)
        {
            var alumno = alumnosServices.Get(x => x.NombreUsuario == model.userName, "").FirstOrDefault();

            if (alumno == null)
                return Ok(new Response()
                {
                    Status = "Error",
                    Message = "Ocurrio un problema al intentar obtener el usuario."
                });

            foreach (var curso in model.cursos.ToList())
            {
                var inscripcionVigente = InscripcionMateriaService.Get(x => x.Fk_Curso == curso.Id && (x.Estado == "CONFIRMADA" || x.Estado == "PENDIENTE") && x.Fk_Alumno == alumno.Id, "");
                if (!inscripcionVigente.Any())
                    InscripcionMateriaService.Insert(new InscripcionesMateria()
                    {
                        Fecha = DateTime.Now,
                        Activo = true,
                        Alumno = alumno,
                        Curso = cursosServices.Get(x => x.Id == curso.Id, "Materia,Formato,Aula").FirstOrDefault(),
                        Materias = materiasService.Get(x => x.Id == curso.Fk_Materia, "Anio,Campo,Carrera").FirstOrDefault(),
                        Estado = "PENDIENTE"
                    });
            }

            return Ok(new Response()
            {
                Status = "Ok",
                Message = "Se ha realizado la operacion con exito."
            });
        }

        [HttpGet("GetByUserName")]
        public IActionResult GetByUserName(string username)
        {
            var im = InscripcionMateriaService.GetByUserName(username);

            if (im == null || !im.Any())
                return Ok(new InscripcionesMateriaAlumnoModel() { Status = "Error", Mensaje = "Ocurrio un problema al obtener las inscripciones a materias." });

            var result = new InscripcionesMateriaAlumnoModel()
            {
                Status = "Ok",
                listaInscripciones = im,
            };

            return Ok(result);
        }

        [HttpGet("GetDetalleInscripcion")]
        public IActionResult GetDetalleInscripcion(int id)
        {

            var result = InscripcionMateriaService.GetDetalleInscripcion(id);

            return Ok(result);
        }

        [HttpGet("GetByFiltro")]
        public IActionResult GetByFiltro(string nombreApellido = "", string dni = "", string carrera = "", string estado = "")
        {
            double alumnoDNI = 0;
            Alumnos alumno = null;
            Carreras _carrera = null;
            List<InscripcionesMateria> result = new List<InscripcionesMateria>();

            if (double.TryParse(dni, out var doubleDNI))
                alumnoDNI = doubleDNI;
            if (!string.IsNullOrEmpty(carrera))
                _carrera = carrerasService.Get(x => x.Descripcion == carrera, "").FirstOrDefault();

            if (string.IsNullOrEmpty(nombreApellido) &&
                string.IsNullOrEmpty(dni) &&
                string.IsNullOrEmpty(carrera) &&
                string.IsNullOrEmpty(estado))
                result = InscripcionMateriaService.Get("Curso,Alumno,Materias").ToList();

            if (!string.IsNullOrEmpty(nombreApellido) || !string.IsNullOrEmpty(dni))
                alumno = alumnosServices.Get(x => (x.NombreCompleto.Contains(nombreApellido)
                || x.NombreCompleto == nombreApellido),
                "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil")
                .FirstOrDefault();

            if (alumno == null && alumnoDNI != 0)
                alumno = alumnosServices.Get(x => x.NroDocumento == alumnoDNI, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno != null)
            {
                result = InscripcionMateriaService
                    .Get(x => x.Alumno.Id == alumno.Id, "Curso,Alumno,Materias")
                    .ToList();
            }

            if (_carrera != null && result.Any())
            {
                var listMateriasPorCarrera = materiasService.Get(x => x.Fk_Carrera == _carrera.Id, "").ToList();
                result = result.Where(x => listMateriasPorCarrera.Any(m => m.Id == x.Curso.Fk_Materia)).ToList();
            }
            else if (_carrera != null)
            {
                var listMateriasPorCarrera = materiasService.Get(x => x.Fk_Carrera == _carrera.Id, "").ToList();
                result.AddRange(InscripcionMateriaService.Get(x => listMateriasPorCarrera.Any(m => m.Id == x.Curso.Fk_Materia), "Curso,Alumno,Materias"));
            }

            if (!string.IsNullOrEmpty(estado) && result.Any())
            {
                result = result.Where(x => x.Estado == estado).ToList();
            }

            foreach (var im in result)
            {
                _carrera = carrerasService.Get(x => x.Id == im.Materias.Fk_Carrera, "").FirstOrDefault();
                im.CarreraNombre = _carrera.Descripcion;
            }

            return Ok(result);
        }
    }
}