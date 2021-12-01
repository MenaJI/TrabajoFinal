using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class FormatosService : BaseServicesImp<Formatos>, IFormatosService
    {
        public SecurityDbContext dataProvider;

        public FormatosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}