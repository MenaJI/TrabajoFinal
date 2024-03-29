using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CarrerasService : BaseServicesImp<Carreras>, ICarrerasService
    {
        private readonly SecurityDbContext dataProvider;

        public CarrerasService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}