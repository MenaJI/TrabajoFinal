using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface ICursosServices : IBaseServices<Cursos>
    {
        void InscripcionesAutomaticasPrimerAño(Alumnos alumno, Carreras carreras);
        List<Cursos> ObtenerCursosByFiltro(CursosFilterModel model);
    }
}