using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IGenerosService
    {
        List<Generos> GetAll();
        Generos GetById(int id);
        Generos GetByDescrip(string descrip);
        void PostGeneros(Generos genero);
        void PutGeneros(Generos genero);
        void DeleteGeneros(Generos genero);
        void SaveChanges();
    }
}