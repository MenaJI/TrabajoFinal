using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CamposService : BaseServicesImp<Campos>, ICamposService
    {
        public SecurityDbContext dataProvider;

        public CamposService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}