using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICursosServices : IBaseServices<Cursos>
    {
        public List<Cursos> ObtenerCursosHabilitadosParaCursar(string username);
    }
}