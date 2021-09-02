using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IAniosService
    {
        List<Anios> GetAll();
        Anios GetById(int id);
        Anios GetByDescrip(string descrip);
        void PostAnios(Anios anio);
        void PutAnios(Anios anio);
        void DeleteAnios(Anios anio);
        void SaveChanges();
    }
}