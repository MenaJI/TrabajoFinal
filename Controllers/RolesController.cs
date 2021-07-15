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
        private IRolesServices rolesServices;
        
        public RolesController(IRolesServices rolServices){ rolesServices = rolServices; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Roles>> GetAll ()
        {
            return Ok(rolesServices.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await rolesServices.GetAllAsync();
        }
        
        [HttpGet("GetUsuario/{id:int}")]
        public ActionResult<Roles> GetById(int id)
        {
            Roles result = rolesServices.GetById(id);
            if (result!= null)
            {
                return Ok(result);
            }
            return NotFound();    
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody]Roles rol)
        {
            rolesServices.PostRol(rol);
            rolesServices.SaveChanges();
            
            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Roles rol)
        {
            rolesServices.PutRol(rol);
            rolesServices.SaveChanges();
            
            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Roles rol)
        {
            rolesServices.DeleteRol(rol);
            rolesServices.SaveChanges();

            return Ok();
        }

        [HttpHead("/")]
        public IActionResult GetActionResult()
        {
            return Ok();
        }
    }
}