using System.Collections.Generic;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CarrerasService : ICarrerasService
    {
        private readonly ApiDbContext dataProvider;
        public CarrerasService(ApiDbContext dataProvider_){
            dataProvider = dataProvider_;
        }

        public void DeleteCarreras(Carreras carrera)
        {
            throw new System.NotImplementedException();
        }

        public List<Carreras> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void PostCarreras(Carreras carrera)
        {
            throw new System.NotImplementedException();
        }

        public void PutCarreras(Carreras carrera)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}