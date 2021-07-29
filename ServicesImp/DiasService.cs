using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
namespace ApiREST.ServicesImp
{
    public class DiasService : IDiasService
    {
        public ApiDbContext dataProvider;

        public DiasService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Dias> GetAll()
        {
            return dataProvider.Dias.ToList();
        }

        public Dias GetById(int id)
        {
            return dataProvider.Dias.FirstOrDefault(x => x.Id == id);
        }

        public Dias GetByDescrip(string descrip)
        {
            return dataProvider.Dias.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostDias(Dias dia)
        {
            await dataProvider.Dias.AddAsync(dia);
        }

        public void PutDias(Dias dia)
        {
            Dias item = GetById(dia.Id);

            if (item != null)
            {
                item.Descrip = dia.Descrip;
            }
        }

        public void DeleteDias(Dias dia)
        {
            if (dataProvider.Dias.Any(r => r.Id == dia.Id))
            {
                dataProvider.Dias.Remove(dia);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}