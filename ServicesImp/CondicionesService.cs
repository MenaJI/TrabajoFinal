using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CondicionesService : BaseServicesImp<Condiciones>, ICondicionesService
    {
        public SecurityDbContext dataProvider;

        public CondicionesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}