using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using System.Linq;


namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class MateriasController : ControllerBase
    {

        private IMateriasService materiasService;

        public MateriasController(IMateriasService materiasService_)
        {

            materiasService = materiasService_;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var materias = materiasService.Get();

            if (materias.Any())
            {
                foreach (var materia in materias)
                {
                    var materiasCorrelativas = materia.MateriasCorrelativas.Split(',');
                    materia.MateriasList = materiasService.Get(m => materiasCorrelativas.Contains(m.Id.ToString()), "").ToList();
                }
            }

            return Ok(materias);
        }
        [HttpGet("GetMateria")]
        public ActionResult<Materias> GetById(int id)
        {
            Materias materia = materiasService.GetByID(id);
            if (materia != null)
            {
                materia.MateriasList = new List<Materias>();
                var materiasCorrelativas = materia.MateriasCorrelativas.Split(',');

                var listMateria = materiasService.Get(m => materiasCorrelativas.Contains(m.Id.ToString()), "").ToList();

                materia.MateriasList.AddRange(listMateria);
            }
            return Ok(materia);
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Materias materias)
        {
            materiasService.Insert(materias);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Materias materias)
        {
            materiasService.Update(materias);

            return Ok();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Materias materias)
        {
            materiasService.Delete(materias);

            return Ok();
        }
    };

}