using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class AulasService : IAulasService
    {
        public SecurityDbContext dataProvider;

        public AulasService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Aulas> GetAll()
        {
            return dataProvider.Aulas.ToList();
        }

        public Aulas GetById(int id)
        {
            return dataProvider.Aulas.FirstOrDefault(x => x.Id == id);
        }

        public Aulas GetByDescrip(string descrip)
        {
            return dataProvider.Aulas.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostAulas(Aulas aula)
        {
            await dataProvider.Aulas.AddAsync(aula);
        }

        public void PutAulas(Aulas aula)
        {
            Aulas item = GetById(aula.Id);

            if (item != null)
            {
                item.Descrip = aula.Descrip;
                item.Activa = aula.Activa;
            }
        }

        public void DeleteAulas(Aulas aula)
        {
            if (dataProvider.Aulas.Any(r => r.Id == aula.Id))
            {
                dataProvider.Aulas.Remove(aula);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}