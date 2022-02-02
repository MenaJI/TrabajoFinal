using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class MateriasServices : BaseServicesImp<Materias>, IMateriasService
    {
        private readonly SecurityDbContext dataProvider;

        public MateriasServices(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}