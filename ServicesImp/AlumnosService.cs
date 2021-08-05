using System.Collections.Generic;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AlumnosService : IAlumnosServices
    {
        private readonly ApiDbContext dataProvider;
        public AlumnosService(ApiDbContext dataProvider_){
            dataProvider = dataProvider_;
        }

        public void DeleteAlumnos(Alumnos alumnos)
        {
            throw new System.NotImplementedException();
        }

        public List<Alumnos> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void PostAlumnos(Alumnos alumnos)
        {
            throw new System.NotImplementedException();
        }

        public void PutAlumnos(Alumnos alumnos)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}