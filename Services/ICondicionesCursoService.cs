using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICondicionesCursoService
    {
        List<CondicionesCurso> GetAll();
        CondicionesCurso GetById(int id);
        CondicionesCurso GetByDescrip(string descrip);
        void PostCondicionesCurso(CondicionesCurso condicionCurso);
        void PutCondicionesCurso(CondicionesCurso condicionCurso);
        void DeleteCondicionesCurso(CondicionesCurso condicionCurso);
        void SaveChanges();
    }
}