using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CondicionesService : ICondicionesService
    {
        public ApiDbContext dataProvider;

        public CondicionesService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Condiciones> GetAll()
        {
            return dataProvider.Condiciones.ToList();
        }

        public Condiciones GetById(int id)
        {
            return dataProvider.Condiciones.FirstOrDefault(x => x.Id == id);
        }

        public Condiciones GetByDescrip(string descrip)
        {
            return dataProvider.Condiciones.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostCondiciones(Condiciones condicion)
        {
            await dataProvider.Condiciones.AddAsync(condicion);
        }

        public void PutCondiciones(Condiciones condicion)
        {
            Condiciones item = GetById(condicion.Id);

            if (item != null)
            {
                item.Descrip = condicion.Descrip;
            }
        }

        public void DeleteCondiciones(Condiciones condicion)
        {
            if (dataProvider.Condiciones.Any(r => r.Id == condicion.Id))
            {
                dataProvider.Condiciones.Remove(condicion);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}