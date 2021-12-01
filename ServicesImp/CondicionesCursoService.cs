using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CondicionesCursoService : BaseServicesImp<CondicionesCurso>, ICondicionesCursoService
    {
        public SecurityDbContext dataProvider;

        public CondicionesCursoService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}