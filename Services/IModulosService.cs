using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IModulosService
    {
        List<Modulos> GetAll();
        Modulos GetById(int id);
        //Modulos GetByDescrip(string descrip);
        void PostModulos(Modulos modulo);
        void PutModulos(Modulos modulo);
        void DeleteModulos(Modulos modulo);
        void SaveChanges();
    }
}