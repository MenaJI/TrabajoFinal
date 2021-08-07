using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class NacionalidadesService : INacionalidadesService
    {
        public SecurityDbContext dataProvider;

        public NacionalidadesService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Nacionalidades> GetAll()
        {

            return dataProvider.Nacionalidades.ToList();
        }

        public Nacionalidades GetById(int id)
        {
            return dataProvider.Nacionalidades.FirstOrDefault(x => x.Id == id);
        }

        public Nacionalidades GetByDescrip(string descrip)
        {
            return dataProvider.Nacionalidades.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostNacionalidades(Nacionalidades nacionalidad)
        {
            await dataProvider.Nacionalidades.AddAsync(nacionalidad);
        }

        public void PutNacionalidades(Nacionalidades nacionalidad)
        {
            Nacionalidades item = GetById(nacionalidad.Id);

            if (item != null)
            {
                item.Descrip = nacionalidad.Descrip;
            }
        }

        public void DeleteNacionalidades(Nacionalidades nacionalidad)
        {
            if (dataProvider.Nacionalidades.Any(r => r.Id == nacionalidad.Id))
            {
                dataProvider.Nacionalidades.Remove(nacionalidad);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}