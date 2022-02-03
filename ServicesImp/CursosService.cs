using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CursosServices : BaseServicesImp<Cursos>, ICursosServices
    {
        public SecurityDbContext dataProvider;

        public CursosServices(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}