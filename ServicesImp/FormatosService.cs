using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class FormatosService : IFormatosService
    {
        public SecurityDbContext dataProvider;

        public FormatosService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Formatos> GetAll()
        {
            return dataProvider.Formatos.ToList();
        }

        public Formatos GetById(int id)
        {
            return dataProvider.Formatos.FirstOrDefault(x => x.Id == id);
        }

        public Formatos GetByDescrip(string descrip)
        {
            return dataProvider.Formatos.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostFormatos(Formatos formato)
        {
            await dataProvider.Formatos.AddAsync(formato);
        }

        public void PutFormatos(Formatos formato)
        {
            Formatos item = GetById(formato.Id);

            if (item != null)
            {
                item.Descrip = formato.Descrip;
            }
        }

        public void DeleteFormatos(Formatos formato)
        {
            if (dataProvider.Formatos.Any(r => r.Id == formato.Id))
            {
                dataProvider.Formatos.Remove(formato);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}