using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AlumnosService : IAlumnosServices
    {
        private readonly SecurityDbContext dataProvider;
        public AlumnosService(SecurityDbContext dataProvider_)
        {
            dataProvider = dataProvider_;
        }

        public void DeleteAlumnos(Alumnos alumnos)
        {
            var alumno = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (alumno != null)
            {
                dataProvider.Alumnos.Remove(alumnos);
            }
        }

        public List<Alumnos> GetAll()
        {
            return dataProvider.Alumnos.ToList();
        }

        public void PostAlumnos(Alumnos alumnos)
        {
            var result = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (result == null)
            {
                dataProvider.Alumnos.Add(result);
            }
        }

        public void PutAlumnos(Alumnos alumnos)
        {
            var result = dataProvider.Alumnos.FirstOrDefault(a => a.Id == alumnos.Id);
            if (result != null)
            {
                result = alumnos;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}