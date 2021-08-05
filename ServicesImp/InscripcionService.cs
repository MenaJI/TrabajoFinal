using System.Collections.Generic;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionService : IInscripcionService
    {
        private readonly ApiDbContext dataProvider;
        public InscripcionService(ApiDbContext dataProvider_){
            dataProvider = dataProvider_;
        }

        public void DeleteInscripcion(InscripcionCarrera inscripcion)
        {
            throw new System.NotImplementedException();
        }

        public List<InscripcionCarrera> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void PostInscripcion(InscripcionCarrera inscripcionCarrera)
        {
            throw new System.NotImplementedException();
        }

        public void PutInscripcion(InscripcionCarrera inscripcionCarrera)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}