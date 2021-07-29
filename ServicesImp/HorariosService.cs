using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class HorariosService : IHorariosService
    {
        public ApiDbContext dataProvider;

        public HorariosService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Horarios> GetAll()
        {
            return dataProvider.Horarios.ToList();
        }

        public Horarios GetById(int id)
        {
            return dataProvider.Horarios.FirstOrDefault(x => x.Id == id);
        }

        public Horarios GetByDescrip(string descrip)
        {
            return dataProvider.Horarios.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostHorarios(Horarios horario)
        {
            await dataProvider.Horarios.AddAsync(horario);
        }

        public void PutHorarios(Horarios horario)
        {
            Horarios item = GetById(horario.Id);

            if (item != null)
            {
                item.Descrip = horario.Descrip;
            }
        }

        public void DeleteHorarios(Horarios horario)
        {
            if (dataProvider.Horarios.Any(r => r.Id == horario.Id))
            {
                dataProvider.Horarios.Remove(horario);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}