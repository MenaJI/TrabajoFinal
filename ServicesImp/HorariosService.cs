using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class HorariosService : BaseServicesImp<Horarios>, IHorariosService
    {
        public SecurityDbContext dataProvider;

        public HorariosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}