using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.Models;
using System.Linq;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class InscripcionCarrerasController : ControllerBase
    {

        private IInscripcionCarreraService inscripcionCarreraService;
        private IAlumnosServices alumnosServices;
        private ICarrerasService carrerasService;
        private ICursosServices cursosServices;

        public InscripcionCarrerasController(IInscripcionCarreraService inscripcionCarreraService_
        , IAlumnosServices alumnosServices_
        , ICarrerasService carrerasService_
        , ICursosServices cursosServices_)
        {

            inscripcionCarreraService = inscripcionCarreraService_;
            alumnosServices = alumnosServices_;
            carrerasService = carrerasService_;
            cursosServices = cursosServices_;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = inscripcionCarreraService.Get("Carrera");

            return Ok(result);
        }

        [HttpGet("GetByFiltro")]
        public IActionResult GetByFiltro(string nombreApellido = "", string dni = "", string carrera = "", string estado = "")
        {
            Alumnos alumno = null;
            int carreraId = 0;
            double alumnoDNI = 0;
            List<InscripcionCarrera> result = new List<InscripcionCarrera>();

            if (string.IsNullOrEmpty(nombreApellido) &&
                string.IsNullOrEmpty(dni) &&
                string.IsNullOrEmpty(carrera) &&
                string.IsNullOrEmpty(estado))
                return Ok(inscripcionCarreraService.Get("Carrera"));

            if (double.TryParse(dni, out var doubleDNI))
                alumnoDNI = doubleDNI;
            if (!string.IsNullOrEmpty(carrera))
                carreraId = carrerasService.Get(x => x.Descripcion == carrera, "").FirstOrDefault().Id;

            if (!string.IsNullOrEmpty(nombreApellido) && nombreApellido != "null")
                alumno = alumnosServices.Get(x => (x.NombreCompleto.Contains(nombreApellido)
                || x.NombreCompleto == nombreApellido),
                "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil")
                .FirstOrDefault();

            if (alumno == null && alumnoDNI != 0)
                alumno = alumnosServices.Get(x => x.NroDocumento == alumnoDNI, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno != null)
                alumno.InscripcionCarreras.ToList().ForEach(ic =>
                {
                    result.Add(inscripcionCarreraService.Get(x => x.Id == ic.Id, "Carrera").FirstOrDefault());
                });

            if (carreraId != 0 && result.Any())
                result = result.Where(ic => ic.Fk_Carrera == carreraId).ToList();
            else if (carreraId != 0)
                result.AddRange(inscripcionCarreraService.Get(ic => ic.Fk_Carrera == carreraId, "Carrera"));

            if (!string.IsNullOrEmpty(estado) && result.Any())
                result = result.Where(ic => ic.Estado == estado).ToList();
            else if (!string.IsNullOrEmpty(estado))
                result.AddRange(inscripcionCarreraService.Get(ic => ic.Estado == estado, "Carrera"));

            return Ok(result);
        }

        [HttpGet("CambiarEstadoInscripcionCarrera")]
        public ActionResult CambiarEstadoInscripcionCarrera(int idInscripcion, string estado)
        {
            InscripcionCarrera result = null;
            var alumno = alumnosServices.Get(a => a.InscripcionCarreras.Any(c => c.Id == idInscripcion), "InscripcionCarreras").FirstOrDefault();
            result = inscripcionCarreraService.Get(x => x.Id == idInscripcion, "Carrera").FirstOrDefault();
            if (!string.IsNullOrEmpty(estado) && result != null)
            {
                var estadoPrevio = result.Estado;
                result.Estado = estado;
                inscripcionCarreraService.Update(result);

                if (estadoPrevio == "PENDIENTE" && estado == "APROBADA")
                    cursosServices.InscripcionesAutomaticasPrimerAño(alumno, result.Carrera);
            }

            return Ok(result);
        }

        [HttpGet("DetallesInscripcion")]
        public ActionResult ObtenerDetallesInscripcionCarrera(int idInscripcionCarrera)
        {
            DetalleInscripcionCarrera result = inscripcionCarreraService.ObtenerDetallesInscripcionCarrera(idInscripcionCarrera);
            if (result != null)
                return Ok(result);

            return NotFound(result);
        }

    };

}