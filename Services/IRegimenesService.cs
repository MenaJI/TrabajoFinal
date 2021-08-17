using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IRegimenesService
    {
        List<Regimenes> GetAll();
        Regimenes GetById(int id);
        Regimenes GetByDescrip(string descrip);
        void PostRegimenes(Regimenes regimen);
        void PutRegimenes(Regimenes regimen);
        void DeleteRegimenes(Regimenes regimen);
        void SaveChanges();
    }
}