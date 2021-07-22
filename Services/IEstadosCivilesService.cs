using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IEstadosCivilesService
    {
        List<EstadosCiviles> GetAll();
        EstadosCiviles GetById(int id);
        EstadosCiviles GetByDescrip(string descrip);
        void PostEstadosCiviles(EstadosCiviles estadoCivil);
        void PutEstadosCiviles(EstadosCiviles estadoCivil);
        void DeleteEstadosCiviles(EstadosCiviles estadoCivil);
        void SaveChanges();
    }
}