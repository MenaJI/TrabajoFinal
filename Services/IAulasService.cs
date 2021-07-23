using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IAulasService
    {
        List<Aulas> GetAll();
        Aulas GetById(int id);
        Aulas GetByDescrip(string descrip);
        void PostAulas(Aulas aula);
        void PutAulas(Aulas aula);
        void DeleteAulas(Aulas aula);
        void SaveChanges();
    }
}