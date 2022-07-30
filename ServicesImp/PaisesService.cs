using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class PaisesService : BaseServicesImp<Paises>, IPaisesService
    {
        public SecurityDbContext dataProvider;

        public PaisesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}