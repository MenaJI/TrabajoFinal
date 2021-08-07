using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class EstadosCivilesService : IEstadosCivilesService
    {
        public SecurityDbContext dataProvider;

        public EstadosCivilesService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<EstadosCiviles> GetAll()
        {

            return dataProvider.EstadosCiviles.ToList();
        }

        public EstadosCiviles GetById(int id)
        {
            return dataProvider.EstadosCiviles.FirstOrDefault(x => x.Id == id);
        }

        public EstadosCiviles GetByDescrip(string descrip)
        {
            return dataProvider.EstadosCiviles.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostEstadosCiviles(EstadosCiviles estadoCivil)
        {
            await dataProvider.EstadosCiviles.AddAsync(estadoCivil);
        }

        public void PutEstadosCiviles(EstadosCiviles estadoCivil)
        {
            EstadosCiviles item = GetById(estadoCivil.Id);

            if (item != null)
            {
                item.Descrip = estadoCivil.Descrip;
            }
        }

        public void DeleteEstadosCiviles(EstadosCiviles estadoCivil)
        {
            if (dataProvider.EstadosCiviles.Any(r => r.Id == estadoCivil.Id))
            {
                dataProvider.EstadosCiviles.Remove(estadoCivil);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}