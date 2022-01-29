using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;
using ApiREST.Models;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivosController : ControllerBase
    {
        private IArchivosServices archivosServices;

        public ArchivosController(IArchivosServices _archivosServices) { archivosServices = _archivosServices; }

        [HttpGet("GetArchivo")]
        public ActionResult<ArchivoModel> GetArchivo(string tipoArchivo, string alumnoUserName)
        {
            ArchivoModel result = archivosServices.ObtenerArchivo(tipoArchivo, alumnoUserName);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] ArchivoModel model)
        {
            archivosServices.Insert(model);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(ArchivoModel model)
        {
            archivosServices.UpdateArchivo(model);

            return NotFound();
        }
    }
}