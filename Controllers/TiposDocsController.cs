using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDocsController : ControllerBase
    {
        private ITiposDocsService tiposDocsService;

        public TiposDocsController(ITiposDocsService tipoDocService) { tiposDocsService = tipoDocService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<TiposDocs>> GetAll()
        {
            return Ok(tiposDocsService.Get());
        }

        [HttpGet("GetTipoDoc/{id:int}")]
        public ActionResult<TiposDocs> GetById(int id)
        {
            TiposDocs result = tiposDocsService.GetByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] TiposDocs tipoDoc)
        {
            tiposDocsService.Insert(tipoDoc);

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(TiposDocs tipoDoc)
        {
            tiposDocsService.Update(tipoDoc);

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(TiposDocs tipoDoc)
        {
            tiposDocsService.Delete(tipoDoc);

            return Ok();
        }
    }
}