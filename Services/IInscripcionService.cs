using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IInscripcionService
    {
        List<InscripcionCarrera> GetAll();
        void PostInscripcion ( InscripcionCarrera inscripcionCarrera);
        void PutInscripcion (InscripcionCarrera inscripcionCarrera);
        void DeleteInscripcion ( InscripcionCarrera inscripcionCarrera);
        void SaveChanges();
    }
}
