using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CondicionesCursoService : ICondicionesCursoService
    {
        public SecurityDbContext dataProvider;

        public CondicionesCursoService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<CondicionesCurso> GetAll()
        {
            return dataProvider.CondicionesCurso.ToList();
        }

        public CondicionesCurso GetById(int id)
        {
            return dataProvider.CondicionesCurso.FirstOrDefault(x => x.Id == id);
        }

        public CondicionesCurso GetByDescrip(string descrip)
        {
            return dataProvider.CondicionesCurso.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostCondicionesCurso(CondicionesCurso condicionCurso)
        {
            await dataProvider.CondicionesCurso.AddAsync(condicionCurso);
        }

        public void PutCondicionesCurso(CondicionesCurso condicionCurso)
        {
            CondicionesCurso item = GetById(condicionCurso.Id);

            if (item != null)
            {
                item.Descrip = condicionCurso.Descrip;
            }
        }

        public void DeleteCondicionesCurso(CondicionesCurso condicionCurso)
        {
            if (dataProvider.CondicionesCurso.Any(r => r.Id == condicionCurso.Id))
            {
                dataProvider.CondicionesCurso.Remove(condicionCurso);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}