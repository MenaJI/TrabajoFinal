using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ApiREST.Entities.DTOs;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
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

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByNombreRol(Rol_DTO model)
        {
            Roles rol = await rolesService.GetByNombreRol(model);

            if (rol != null)
            {
                return Ok(rol);
            }

            return NoContent();
        }

        [HttpPost("RegistrarRol")]
        public async Task<IActionResult> AddItem(Rol_DTO model)
        {
            var result = await rolesService.PostRol(model);

            return Ok(result);
        }

        [HttpDelete("BorrarRol")]
        public IActionResult RemoveItem(string model)
        {
            var result = rolesService.DeleteRol(model);

            return Ok(result);
        }

    }
}