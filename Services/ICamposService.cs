using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ICamposService
    {
        List<Campos> GetAll();
        Campos GetById(int id);
        Campos GetByDescrip(string descrip);
        void PostCampos(Campos campo);
        void PutCampos(Campos campo);
        void DeleteCampos(Campos campo);
        void SaveChanges();
    }
}