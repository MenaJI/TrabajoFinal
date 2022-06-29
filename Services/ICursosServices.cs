using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICursosServices : IBaseServices<Cursos>
    {
        public List<Cursos> ObtenerCursosDisponibles(string username);
        public InscripcionesMateria RealizarInscripcion(int cursoId, string username);

        void InscripcionesAutomaticasPrimerAño(Alumnos alumno, Carreras carreras);
    }
}