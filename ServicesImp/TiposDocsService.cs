using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class TiposDocsService : BaseServicesImp<TiposDocs>, ITiposDocsService
    {
        public SecurityDbContext dataProvider;

        public TiposDocsService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}