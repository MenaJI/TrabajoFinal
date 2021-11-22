using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AniosService : BaseServicesImp<Anios>, IAniosService
    {
        public SecurityDbContext dataProvider;

        public AniosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}