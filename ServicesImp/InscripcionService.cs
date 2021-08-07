using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionService : IInscripcionService
    {
        private readonly SecurityDbContext dataProvider;
        public InscripcionService(SecurityDbContext dataProvider_)
        {
            dataProvider = dataProvider_;
        }

        public void DeleteInscripcion(InscripcionCarrera inscripcion)
        {
            var result = dataProvider.InscripcionCarreras.FirstOrDefault(i => i.Id == inscripcion.Id);
            if (result != null)
            {
                dataProvider.InscripcionCarreras.Remove(result);
            }
        }

        public List<InscripcionCarrera> GetAll()
        {
            return dataProvider.InscripcionCarreras.ToList();
        }

        public void PostInscripcion(InscripcionCarrera inscripcionCarrera)
        {
            dataProvider.Remove(inscripcionCarrera);
        }

        public void PutInscripcion(InscripcionCarrera inscripcionCarrera)
        {
            var result = dataProvider.InscripcionCarreras.FirstOrDefault(i => i.Id == inscripcionCarrera.Id);
            if (result != null)
            {
                result = inscripcionCarrera;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}