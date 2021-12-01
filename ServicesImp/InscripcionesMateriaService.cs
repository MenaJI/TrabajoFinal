using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionesMateriaService : BaseServicesImp<InscripcionesMateria>, IInscripcionesMateriaService
    {
        private readonly SecurityDbContext dataProvider;

        public InscripcionesMateriaService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }
    }
}