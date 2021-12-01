using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AulasService : BaseServicesImp<Aulas>, IAulasService
    {
        public SecurityDbContext dataProvider;

        public AulasService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}