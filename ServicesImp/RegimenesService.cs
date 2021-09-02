using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class RegimenesService : IRegimenesService
    {
        public SecurityDbContext dataProvider;

        public RegimenesService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Regimenes> GetAll()
        {
            return dataProvider.Regimenes.ToList();
        }

        public Regimenes GetById(int id)
        {
            return dataProvider.Regimenes.FirstOrDefault(x => x.Id == id);
        }

        public Regimenes GetByDescrip(string descrip)
        {
            return dataProvider.Regimenes.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostRegimenes(Regimenes regimen)
        {
            await dataProvider.Regimenes.AddAsync(regimen);
        }

        public void PutRegimenes(Regimenes regimen)
        {
            Regimenes item = GetById(regimen.Id);

            if (item != null)
            {
                item.Descrip = regimen.Descrip;
            }
        }

        public void DeleteRegimenes(Regimenes regimen)
        {
            if (dataProvider.Regimenes.Any(r => r.Id == regimen.Id))
            {
                dataProvider.Regimenes.Remove(regimen);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}