using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private ICursosServices cursosServices;
        private IModulosService modulosService;
        private IDocentesServices docentesServices;

        public CursosController(ICursosServices _cursosServices, IModulosService _modulosService, IDocentesServices _docentesService)
        {
            cursosServices = _cursosServices;
            modulosService = _modulosService;
            docentesServices = _docentesService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Cursos>> GetAll()
        {

            var cursos = cursosServices.Get("Formato,Aula,Materia,CondicionCurso");

            if (cursos.Any())
            {
                foreach (var curso in cursos)
                {
                    var modulosId = curso.ModulosId.Split(',');
                    curso.Modulos = modulosService.Get(m => modulosId.Contains(m.Id.ToString()), "Dia,Horario").ToList();

                    var docentesId = curso.DocentesId.Split(',');
                    curso.Docentes = docentesServices.Get(d => docentesId.Contains(d.Id.ToString()), "TipoDoc,Genero,Nacionalidad,EstadoCivil").ToList();
                }
            }

            return Ok(cursos);
        }

        [HttpGet("GetCurso")]
        public ActionResult<Cursos> GetById(int id)
        {
            Cursos curso = cursosServices.GetByID(id);
            if (curso != null)
            {
                curso.Modulos = new List<Modulos>();
                var modulosId = curso.ModulosId.Split(',');

                curso.Modulos = modulosService.Get(m => modulosId.Contains(m.Id.ToString()), "Dia,Horario").ToList();

                var docentesId = curso.DocentesId.Split(',');
                curso.Docentes = docentesServices.Get(d => docentesId.Contains(d.Id.ToString()), "TipoDoc,Genero,Nacionalidad,EstadoCivil").ToList();
            }

            return Ok(curso);
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Cursos cursos)
        {
            cursosServices.Insert(cursos);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Cursos cursos)
        {
            cursosServices.Update(cursos);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Cursos cursos)
        {
            cursosServices.Delete(cursos);

            return Ok();
        }
    }
}