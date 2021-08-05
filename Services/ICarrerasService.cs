using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICarrerasService
    {
        
        List<Carreras> GetAll();
        void PostCarreras ( Carreras carrera);
        void PutCarreras (Carreras carrera);
        void DeleteCarreras ( Carreras carrera);
        void SaveChanges();
    }
}