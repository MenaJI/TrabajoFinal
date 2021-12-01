using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class EstadosCivilesService : BaseServicesImp<EstadosCiviles>, IEstadosCivilesService
    {
        public SecurityDbContext dataProvider;

        public EstadosCivilesService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}