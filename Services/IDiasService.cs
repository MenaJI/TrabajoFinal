using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IDiasService
    {
        List<Dias> GetAll();
        Dias GetById(int id);
        Dias GetByDescrip(string descrip);
        void PostDias(Dias dia);
        void PutDias(Dias dia);
        void DeleteDias(Dias dia);
        void SaveChanges();
    }
}