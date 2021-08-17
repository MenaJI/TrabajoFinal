using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IFormatosService
    {
        List<Formatos> GetAll();
        Formatos GetById(int id);
        Formatos GetByDescrip(string descrip);
        void PostFormatos(Formatos formato);
        void PutFormatos(Formatos formato);
        void DeleteFormatos(Formatos formato);
        void SaveChanges();
    }
}