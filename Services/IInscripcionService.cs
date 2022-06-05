using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IInscripcionCarreraService : IBaseServices<InscripcionCarrera>
    {
        public DetalleInscripcionCarrera ObtenerDetallesInscripcionCarrera(int IdInscripcion);
    }
}
