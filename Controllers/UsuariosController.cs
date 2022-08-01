using System;
using System.Threading.Tasks;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {

        public IUsuariosService usuariosService;
        public IEmailService emailService;

        public UsuariosController(IUsuariosService _usuariosServices, IEmailService _emailService)
        {
            usuariosService = _usuariosServices;
            emailService = _emailService;
        }

        [HttpGet("GelAll")]
        public IActionResult GetAll()
        {
            return Ok(usuariosService.GetAll());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var result = await usuariosService.Login(model);
            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> Registro([FromBody] RegistroModel model, string rol = "Alumno")
        {

            var result = await usuariosService.RegistrarUsuario(model, rol);

            return Ok(result);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm]MailRequest request)
        {  
            await emailService.SendEmailAsync(request);
            return Ok();   
        }

        [HttpGet("RecuperarContrasenia")]
        public async Task<IActionResult> RecuperarContrasenia(string userIdentification, string direccion){
            
            var result = await usuariosService.RecuperarContrasenia(userIdentification, direccion);

            return Ok(result);
        }

        [HttpGet("CambiarContrasenia")]
        public async Task<IActionResult> CambiarContrasenia(string userIdentification, string nuevaContrasenia){
            
            var result = await usuariosService.CambiarContrasenia(userIdentification, nuevaContrasenia);
            
            return Ok(result);
        }

        [HttpGet("VerificarUsuario")]
        public async Task<IActionResult> VerificarUsuario(string userCode){
            
            var result = await usuariosService.VerificarUsuario(userCode);
            
            return Ok(result);
        }
    }
}