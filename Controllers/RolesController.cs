using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private IRolesService rolesService;

        public RolesController(IRolesService _rolesService) { rolesService = _rolesService; }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = rolesService.GetAll();

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpPost("RegistrarRol")]
        public async Task<IActionResult> AddItem(RolModel model)
        {
            var result = await rolesService.PostRol(model);

            return Ok(result);
        }

        [HttpDelete("BorrarRol")]
        public IActionResult RemoveItem(RolModel model)
        {
            var result = rolesService.DeleteRol(model);

            return Ok(result);
        }

    }
}