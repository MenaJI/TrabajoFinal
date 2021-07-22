using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface ITiposDocsService
    {
        List<TiposDocs> GetAll();
        TiposDocs GetById(int id);
        TiposDocs GetByDescrip(string descrip);
        void PostTiposDocs(TiposDocs tipoDoc);
        void PutTiposDocs(TiposDocs tipoDoc);
        void DeleteTiposDocs(TiposDocs tipoDoc);
        void SaveChanges();
    }
}