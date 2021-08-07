using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class LocalidadesService : ILocalidadesService
    {
        public SecurityDbContext dataProvider;

        public LocalidadesService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Localidades> GetAll()
        {

            return dataProvider.Localidades.ToList();
        }

        public Localidades GetById(int id)
        {
            return dataProvider.Localidades.FirstOrDefault(x => x.Id == id);
        }

        public Localidades GetByDescrip(string descrip)
        {
            return dataProvider.Localidades.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostLocalidades(Localidades localidad)
        {
            await dataProvider.Localidades.AddAsync(localidad);
        }

        public void PutLocalidades(Localidades localidad)
        {
            Localidades item = GetById(localidad.Id);

            if (item != null)
            {
                item.Descrip = localidad.Descrip;
            }
        }

        public void DeleteLocalidades(Localidades localidad)
        {
            if (dataProvider.Localidades.Any(r => r.Id == localidad.Id))
            {
                dataProvider.Localidades.Remove(localidad);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}