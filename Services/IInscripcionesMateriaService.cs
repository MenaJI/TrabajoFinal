using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IInscripcionesMateriaService : IBaseServices<InscripcionesMateria>
    {
        List<InscripcionesMateria> GetByUserName(string username);
        DetalleInscripcionMateriaModel GetDetalleInscripcion(int id);
    }
}