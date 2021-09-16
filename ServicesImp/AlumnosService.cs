using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.ServicesImp
{
    public class AlumnosService : IAlumnosServices
    {
        private readonly SecurityDbContext dataProvider;
        private readonly UserManager<Usuarios> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AlumnosService(SecurityDbContext dataProvider_, UserManager<Usuarios> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            dataProvider = dataProvider_;
            roleManager = _roleManager;
        }

        public void DeleteAlumnos(Alumnos alumnos)
        {
            var alumno = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (alumno != null)
            {
                dataProvider.Alumnos.Remove(alumnos);
            }
        }

        public List<Alumnos> GetAll()
        {
            return dataProvider.Alumnos.Include("Usuario").Include("Roles").ToList();
        }

        public void PostAlumnos(Alumnos alumnos)
        {
            var result = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (result == null)
            {
                dataProvider.Alumnos.Add(result);
            }
        }

        public void PutAlumnos(Alumnos alumnos)
        {
            var result = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (result != null)
            {
                result = alumnos;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}