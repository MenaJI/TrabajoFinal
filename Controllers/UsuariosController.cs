using System.Threading.Tasks;
using ApiREST.DTOs;
using ApiREST.Models;
using ApiREST.Services;
using ApiREST.ServicesImp;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {

        public IUsuariosService usuariosService;

        public UsuariosController(IUsuariosService _usuariosServices)
        {
            usuariosService = _usuariosServices;
        }

        [HttpGet("GelAll")]
        public IActionResult GetAll()
        {
            return Ok(usuariosService.GetAll());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login_DTO model)
        {

            var result = await usuariosService.Login(model);
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> Registro([FromBody] Registro_DTO model)
        {

            var result = await usuariosService.RegistrarUsuario(model);

            return Ok(result);
        }

    }
}