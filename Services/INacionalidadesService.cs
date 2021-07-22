using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface INacionalidadesService
    {
        List<Nacionalidades> GetAll();
        Nacionalidades GetById(int id);
        Nacionalidades GetByDescrip(string descrip);
        void PostNacionalidades(Nacionalidades nacionalidad);
        void PutNacionalidades(Nacionalidades nacionalidad);
        void DeleteNacionalidades(Nacionalidades nacionalidad);
        void SaveChanges();
    }
}