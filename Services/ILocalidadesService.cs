using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ILocalidadesService
    {
        List<Localidades> GetAll();
        Localidades GetById(int id);
        Localidades GetByDescrip(string descrip);
        void PostLocalidades(Localidades localidad);
        void PutLocalidades(Localidades localidad);
        void DeleteLocalidades(Localidades localidad);
        void SaveChanges();
    }
}