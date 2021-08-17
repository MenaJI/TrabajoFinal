using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AniosService : IAniosService
    {
        public SecurityDbContext dataProvider;

        public AniosService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Anios> GetAll()
        {
            return dataProvider.Anios.ToList();
        }

        public Anios GetById(int id)
        {
            return dataProvider.Anios.FirstOrDefault(x => x.Id == id);
        }

        public Anios GetByDescrip(string descrip)
        {
            return dataProvider.Anios.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostAnios(Anios anio)
        {
            await dataProvider.Anios.AddAsync(anio);
        }

        public void PutAnios(Anios anio)
        {
            Anios item = GetById(anio.Id);

            if (item != null)
            {
                item.Descrip = anio.Descrip;
            }
        }

        public void DeleteAnios(Anios anio)
        {
            if (dataProvider.Anios.Any(r => r.Id == anio.Id))
            {
                dataProvider.Anios.Remove(anio);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}