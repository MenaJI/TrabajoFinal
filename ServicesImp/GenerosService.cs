using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class GenerosService : BaseServicesImp<Generos>, IGenerosService
    {
        public SecurityDbContext dataProvider;

        public GenerosService(SecurityDbContext context) : base(context)
        {
        }
    }
}