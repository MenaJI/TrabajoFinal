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
using ApiREST.DTOs;

namespace ApiREST.ServicesImp
{
    public class UsuariosService : IUsuariosService
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IMapper iMapper;

        public UsuariosService(UserManager<Usuarios> _userManager,
         RoleManager<IdentityRole> _roleManager, IConfiguration _configuration, IMapper _iMapper)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            configuration = _configuration;
            iMapper = _iMapper;
        }

        public void BorrarUsuario(Usuarios usuario)
        {
            throw new System.NotImplementedException();
        }

        public void EditarUsuario(Usuarios usuario)
        {
            throw new System.NotImplementedException();
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

        public async Task<TokenModel> Login(Login_DTO model)
        {
            var user = await userManager.FindByNameAsync(model.NombreUsuario);

            TokenModel result = null;

            if (user != null && await userManager.CheckPasswordAsync(user, model.Contraseña))
            {
                // Solicita el rol del usuario.
                var userRoles = await userManager.GetRolesAsync(user);

                // Se crea una lista de los Claims que va a tener el JWT.
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
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
                    Expiracion = token.ValidTo,
                };

                return result;
            }

            return result;
        }

        public async Task<Response> RegistrarUsuario(Registro_DTO model)
        {
            var userExists = await userManager.FindByNameAsync(model.NombreUsuario);

            if (userExists != null)
            {
                return new Response() { Status = "Error", Message = "El usuario ya existe." };
            }

            Usuarios usuario = new Usuarios()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.NombreUsuario,
                //FechaCreacion = DateTime.Now
            };

            var result = await userManager.CreateAsync(usuario, model.Contraseña);

            if (!result.Succeeded)
            {
                return new Response { Status = "Error", Message = "La creacion del usuario fallo. Vuelva a intentarlo." };
            }

            return new Response { Status = "Success", Message = "El usuario fue creado con exito." };
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}