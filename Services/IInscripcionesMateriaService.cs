using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IInscripcionesMateriaService : IBaseServices<InscripcionesMateria>
    {
        List<InscripcionesMateria> GetByUserName(string username);
    }
}