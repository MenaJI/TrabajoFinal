using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class GenerosService : IGenerosService
    {
        public ApiDbContext dataProvider;

        public GenerosService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Generos> GetAll()
        {

            return dataProvider.Generos.ToList();
        }

        public Generos GetById(int id)
        {
            return dataProvider.Generos.FirstOrDefault(x => x.Id == id);
        }

        public Generos GetByDescrip(string descrip)
        {
            return dataProvider.Generos.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostGeneros(Generos genero)
        {
            await dataProvider.Generos.AddAsync(genero);
        }

        public void PutGeneros(Generos genero)
        {
            Generos item = GetById(genero.Id);

            if (item != null)
            {
                item.Descrip = genero.Descrip;
            }
        }

        public void DeleteGeneros(Generos genero)
        {
            if (dataProvider.Generos.Any(r => r.Id == genero.Id))
            {
                dataProvider.Generos.Remove(genero);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}