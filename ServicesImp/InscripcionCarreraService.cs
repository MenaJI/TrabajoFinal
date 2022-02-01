using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionCarreraService : BaseServicesImp<InscripcionCarrera>, IInscripcionCarreraService
    {
        private readonly SecurityDbContext dataProvider;

        public InscripcionCarreraService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }

        // public IEnumerable<InscripcionCarrera> obtenerInscripcionesCarrera(int Id, string Propiedades){
        //     IQueryable<InscripcionCarrera> Query = 
        // }

    }
}