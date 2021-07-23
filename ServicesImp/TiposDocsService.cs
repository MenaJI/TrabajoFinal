using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class TiposDocsService : ITiposDocsService
    {
        public ApiDbContext dataProvider;

        public TiposDocsService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<TiposDocs> GetAll()
        {

            return dataProvider.TiposDocs.ToList();
        }

        public TiposDocs GetById(int id)
        {
            return dataProvider.TiposDocs.FirstOrDefault(x => x.Id == id);
        }

        public TiposDocs GetByDescrip(string descrip)
        {
            return dataProvider.TiposDocs.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostTiposDocs(TiposDocs tipoDoc)
        {
            await dataProvider.TiposDocs.AddAsync(tipoDoc);
        }

        public void PutTiposDocs(TiposDocs tipoDoc)
        {
            TiposDocs item = GetById(tipoDoc.Id);

            if (item != null)
            {
                item.Descrip = tipoDoc.Descrip;
            }
        }

        public void DeleteTiposDocs(TiposDocs tipoDoc)
        {
            if (dataProvider.TiposDocs.Any(r => r.Id == tipoDoc.Id))
            {
                dataProvider.TiposDocs.Remove(tipoDoc);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}