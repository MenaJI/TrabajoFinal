using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiREST.ServicesImp
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper iMapper;

        public RolesService(RoleManager<IdentityRole> _roleManager, IMapper _iMapper)
        {
            roleManager = _roleManager;
            iMapper = _iMapper;
        }

        public Response DeleteRol(RolModel model)
        {
            var rol = roleManager.Roles.FirstOrDefault(x => x.Name == model.Nombre);

            if (rol != null)
            {
                roleManager.DeleteAsync(rol);

                return new Response { Status = "Success", Message = "El rol fue eliminado correctamente." };
            }

            return new Response { Status = "Error", Message = $"No se a podido eliminar el rol {model.Nombre}" };
        }

        public List<Roles> GetAll()
        {
            var rolList = roleManager.Roles.ToList();
            List<Roles> result = new List<Roles>();

            foreach (var rol in rolList)
            {
                result.Add(iMapper.Map<Roles>(rol));
            }

            return result;
        }

        public async Task<Roles> GetByNombreRol(RolModel model)
        {
            var rolExist = await roleManager.FindByNameAsync(model.Nombre);
            if (rolExist != null)
            {
                var rol = iMapper.Map<Roles>(rolExist);
                return rol;
            }
            return null;
        }

        public async Task<Response> PostRol(RolModel model)
        {
            var rolExist = await roleManager.FindByNameAsync(model.Nombre);

            if (rolExist != null)
            {
                return new Response() { Status = "Error", Message = "El rol ya existe." };
            }

            Roles rol = new Roles() { Name = model.Nombre };

            var result = await roleManager.CreateAsync(rol);

            // Verifica que se haya creado correctamente el rol.
            if (!result.Succeeded)
            {
                return new Response { Status = "Error", Message = "La creacion del rol fallo. Vuelva a intentarlo." };
            }

            return new Response { Status = "Success", Message = "El rol fue creado con exito." };
        }

        public void PutRol(Roles rol)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}