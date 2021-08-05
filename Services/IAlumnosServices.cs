using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IAlumnosServices
    {
        List<Alumnos> GetAll();
        void PostAlumnos ( Alumnos alumnos);
        void PutAlumnos (Alumnos alumnos);
        void DeleteAlumnos ( Alumnos alumnos);
        void SaveChanges();
    }
}
