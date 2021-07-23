using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICondicionesService
    {
        List<Condiciones> GetAll();
        Condiciones GetById(int id);
        Condiciones GetByDescrip(string descrip);
        void PostCondiciones(Condiciones condicion);
        void PutCondiciones(Condiciones condicion);
        void DeleteCondiciones(Condiciones condicion);
        void SaveChanges();
    }
}