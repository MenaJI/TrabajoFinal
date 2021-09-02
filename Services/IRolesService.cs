using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.DTOs;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IRolesService
    {
        List<Roles> GetAll();
        Task<Roles> GetByNombreRol(Rol_DTO model);
        Task<Response> PostRol(Rol_DTO model);
        void PutRol(Roles rol);
        Response DeleteRol(string model);
        void SaveChanges();
    }
}