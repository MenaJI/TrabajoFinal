using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class LocalidadesService : BaseServicesImp<Localidades>, ILocalidadesService
    {
        public SecurityDbContext dataProvider;

        public LocalidadesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}