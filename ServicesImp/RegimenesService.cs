using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class RegimenesService : BaseServicesImp<Regimenes>, IRegimenesService
    {
        public SecurityDbContext dataProvider;

        public RegimenesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}