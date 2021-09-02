using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IInscripcionesMateriaService
    {
        List<InscripcionesMateria> GetAll();
        void PostInscripcionMateria(InscripcionesMateria InscripcionesMateria);
        void PutInscripcionMateria(InscripcionesMateria InscripcionesMateria);
        void DeleteInscripcionMateria(InscripcionesMateria InscripcionesMateria);
        void SaveChanges();
    }
}