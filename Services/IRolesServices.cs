using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IRolesServices
    {
        List<Roles> GetAll();
        Task<List<Roles>> GetAllAsync();
        Roles GetById(int id);
        Roles GetByDescrip (string descrip);
        void PostRol ( Roles rol);
        void PutRol (Roles rol);
        void DeleteRol ( Roles rol);
        void SaveChanges();
    }
}