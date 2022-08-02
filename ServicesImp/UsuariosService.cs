using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using AutoMapper;
using System.Security.Cryptography;

namespace ApiREST.ServicesImp
{
    public class UsuariosService : IUsuariosService
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IMapper iMapper;
        private readonly IEmailService emailService;

        public UsuariosService(UserManager<Usuarios> _userManager,
         RoleManager<IdentityRole> _roleManager, IConfiguration _configuration, IMapper _iMapper, IEmailService _emailService)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            configuration = _configuration;
            iMapper = _iMapper;
            emailService = _emailService;
        }

        public void BorrarUsuario(UsuarioModel usuario)
        {
            var result = userManager.FindByNameAsync(usuario.NombreUsuario);
            if (result != null)
            {
                userManager.DeleteAsync(iMapper.Map<Usuarios>(result));
            }
        }

        public List<Usuarios> GetAll()
        {
            var userList = userManager.Users.ToList();
            List<Usuarios> result = new List<Usuarios>();

            foreach (var user in userList)
            {
                result.Add(iMapper.Map<Usuarios>(user));
            }

            return result;
        }

        public async Task<Response> VerificarUsuario(string emailEncriptado)
        {
            var result = new Response();

            var user = await userManager.FindByNameAsync(emailEncriptado);
            if (user == null)
                return new Response() { Status = "Error", Message = "Correo o nombre de usuario incorrecto." };

            user.EmailConfirmed = true;

            await userManager.UpdateAsync(user);

            result.Status = "Ok";
            result.Message = "El usuario ha sido verificado correctamente.";

            return result;
        }

        public async Task<Response> RecuperarContrasenia(string userIdentification, string direccion)
        {

            var user = await userManager.FindByNameAsync(userIdentification);
            if (user == null)
                user = await this.userManager.FindByEmailAsync(userIdentification);

            if (user == null)
                return new Response() { Status = "Error", Message = "Correo o nombre de usuario incorrecto." };

            var result = new Response();

            await emailService.SendEmailAsync(new MailRequest()
            {
                ToEmail = user.Email,
                Subject = "Recuperar contraseña",
                Body = $"Para recuperar contraseña haga click <a href='http://localhost:4200/usuario/cambiar-contrasenia?userName={user.UserName}'>aqui!</a>",
            });

            result.Status = "Ok";
            result.Message = "Se ha enviado un correo electrónico para restablecer la contraseña.";

            return result;
        }

        public async Task<TokenModel> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.nombreusuario);
            if (user == null)
                user = await this.userManager.FindByEmailAsync(model.nombreusuario);

            TokenModel result = null;

            if (!user.EmailConfirmed)
                return result;

            if (user != null && await userManager.CheckPasswordAsync(user, model.contraseña))
            {
                // Solicita el rol del usuario.
                var userRoles = await userManager.GetRolesAsync(user);
                string roles = "";

                // Se crea una lista de los Claims que va a tener el JWT.
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    roles += userRole.ToString();
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                // Se crea el token de seguridad.
                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                // Se crea el mensaje de respuesta.
                result = new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    NombreUsuario = user.UserName,
                    Rol = roles,
                    Status = "OK"
                };

                return result;
            }

            return result;
        }

        public async Task<Response> RegistrarUsuario(RegistroModel model, string Rol = "")
        {
            try
            {
                var codigoVerificacion = model.NombreUsuario;

                await emailService.SendEmailAsync(new MailRequest()
                {
                    ToEmail = model.Email,
                    Subject = "Verificacion de contraseña",
                    Body = $" Para verificar el usuario haga click <a href='http://localhost:4200/usuario/verificacion?userCode={codigoVerificacion}'>aquí</a>",
                });

                var userExists = await userManager.FindByNameAsync(model.NombreUsuario);

                if (userExists != null)
                {
                    return new Response() { Status = "Error", Message = "El usuario ya existe." };
                }

                var rolBase = roleManager.Roles.FirstOrDefault(r => r.Name == Rol);

                if (rolBase == null)
                {
                    return new Response() { Status = "Error", Message = "El rol predeterminado de 'Alumno' no existe." };
                }

                Usuarios usuario = new Usuarios()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.NombreUsuario,
                    Contrasenia = model.Contraseña,
                };

                var result = await userManager.CreateAsync(usuario, model.Contraseña);

                if (!result.Succeeded)
                {
                    return new Response { Status = "Error", Message = "La creacion del usuario fallo. Vuelva a intentarlo." };
                }

                await userManager.AddToRoleAsync(usuario, rolBase.ToString());


                return new Response { Status = "Success", Message = "El usuario fue creado con exito." };

            }
            catch (Exception ex)
            {
                return new Response() { Status = "Error", Message = ex.InnerException.Message };
            }
        }

        public async Task<Response> CambiarContrasenia(string userIdentification, string nuevaContrasenia)
        {
            var user = await userManager.FindByNameAsync(userIdentification);

            if (user == null)
                return new Response() { Status = "ERROR", Message = "Error al obtener el usuario" };
            var contrasenia = user.Contrasenia;
            await userManager.ChangePasswordAsync(user, user.Contrasenia, nuevaContrasenia);

            user.Contrasenia = nuevaContrasenia;
            await userManager.UpdateAsync(user);

            var response = new Response()
            {
                Status = "OK",
                Message = "Se cambio la contraseña correctamente."
            };

            return response;
        }
    }
}