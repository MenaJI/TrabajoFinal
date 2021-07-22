using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private IRolesService rolesService;

        public RolesController(IRolesService rolService) { rolesService = rolService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Roles>> GetAll()
        {
            return Ok(rolesService.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await rolesService.GetAllAsync();
        }

        [HttpGet("GetUsuario/{id:int}")]
        public ActionResult<Roles> GetById(int id)
        {
            Roles result = rolesService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Roles rol)
        {
            rolesService.PostRol(rol);
            rolesService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Roles rol)
        {
            rolesService.PutRol(rol);
            rolesService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Roles rol)
        {
            rolesService.DeleteRol(rol);
            rolesService.SaveChanges();

            return Ok();
        }

        [HttpHead("/")]
        public IActionResult GetActionResult()
        {
            return Ok();
        }
    }
}