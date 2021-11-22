using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.ServicesImp
{
    public class AlumnosService : BaseServicesImp<Alumnos>, IAlumnosServices
    {
        private readonly SecurityDbContext dataProvider;
        // private readonly UserManager<Usuarios> userManager;
        // private readonly RoleManager<IdentityRole> roleManager;
        public AlumnosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}