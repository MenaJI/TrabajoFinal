using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class DocentesServices : BaseServicesImp<Docentes>, IDocentesServices
    {
        public SecurityDbContext dataProvider;

        public DocentesServices(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}