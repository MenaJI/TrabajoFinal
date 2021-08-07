using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class ModulosService : IModulosService
    {
        public SecurityDbContext dataProvider;

        public ModulosService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Modulos> GetAll()
        {
            return dataProvider.Modulos.ToList();
        }

        public Modulos GetById(int id)
        {
            return dataProvider.Modulos.FirstOrDefault(x => x.Id == id);
        }

        //public Modulos GetByDescrip(string descrip)
        //{
        //    return dataProvider.Modulos.FirstOrDefault(x => x.Descrip == descrip);
        //}

        public async void PostModulos(Modulos modulo)
        {
            await dataProvider.Modulos.AddAsync(modulo);
        }

        public void PutModulos(Modulos modulo)
        {
            Modulos item = GetById(modulo.Id);

            if (item != null)
            {
                item.Dia = modulo.Dia;
                item.Horario = modulo.Horario;
                item.Estado = modulo.Estado;
            }
        }

        public void DeleteModulos(Modulos modulo)
        {
            if (dataProvider.Modulos.Any(r => r.Id == modulo.Id))
            {
                dataProvider.Modulos.Remove(modulo);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}