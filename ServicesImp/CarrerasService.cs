using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CarrerasService : ICarrerasService
    {
        private readonly SecurityDbContext dataProvider;
        public CarrerasService(SecurityDbContext dataProvider_)
        {
            dataProvider = dataProvider_;
        }

        public void DeleteCarreras(Carreras carrera)
        {
            var result = dataProvider.Carreras.FirstOrDefault(c => c.Id == carrera.Id);
            if (result != null)
            {
                dataProvider.Carreras.Remove(result);
            }
        }

        public List<Carreras> GetAll()
        {
            return dataProvider.Carreras.ToList();
        }

        public void PostCarreras(Carreras carrera)
        {
            dataProvider.Add(carrera);
        }

        public void PutCarreras(Carreras carrera)
        {
            var result = dataProvider.Carreras.FirstOrDefault(c => c.Id == carrera.Id);
            if (result != null)
            {
                result = carrera;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}