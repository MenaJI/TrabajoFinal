using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface ICursosServices : IBaseServices<Cursos>
    {
        // public List<Cursos> ObtenerCursosDisponibles(string username);
        
        public InscripcionesMateria RealizarInscripcion(int cursoId, string username);

        void InscripcionesAutomaticasPrimerAño(Alumnos alumno, Carreras carreras);
        List<Cursos> ObtenerCursosByFiltro(CursosFilterModel model);
    }
}