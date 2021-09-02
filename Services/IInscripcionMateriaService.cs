using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IInscripcionMateriasService
    {
        List<InscripcionMateria> GetAll();
        void PostInscripcionMateria ( InscripcionMateria inscripcionMateria);
        void PutInscripcionMateria ( InscripcionMateria inscripcionMateria);
        void DeleteInscripcionMateria ( InscripcionMateria inscripcionMateria);
        void SaveChanges();
    }
}