using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class NacionalidadesService : BaseServicesImp<Nacionalidades>, INacionalidadesService
    {
        public SecurityDbContext dataProvider;

        public NacionalidadesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}