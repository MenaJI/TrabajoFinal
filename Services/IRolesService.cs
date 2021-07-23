using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IRolesService
    {
        List<Roles> GetAll();
        Roles GetByNombreRol(string nombreRol);
        Task<Response> PostRol(RolModel model);
        void PutRol(Roles rol);
        Response DeleteRol(RolModel model);
        void SaveChanges();
    }
}