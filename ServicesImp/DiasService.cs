using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
namespace ApiREST.ServicesImp
{
    public class DiasService : BaseServicesImp<Dias>, IDiasService
    {
        public SecurityDbContext dataProvider;

        public DiasService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}