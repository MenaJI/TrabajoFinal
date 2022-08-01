using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class PeriodosService : BaseServicesImp<Periodos>, IPeriodosService
    {
        public SecurityDbContext dataProvider;

        public PeriodosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}