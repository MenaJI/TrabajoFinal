using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class ModulosService : BaseServicesImp<Modulos>, IModulosService
    {
        public SecurityDbContext dataProvider;

        public ModulosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}