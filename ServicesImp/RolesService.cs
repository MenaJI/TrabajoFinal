using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class RolesService : IRolesService
    {
        public ApiDbContext dataProvider;

        public RolesService(ApiDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Roles> GetAll()
        {

            return dataProvider.Roles.ToList();
        }

        public Roles GetById(int id)
        {
            return dataProvider.Roles.FirstOrDefault(rol => rol.Id == id);
        }

        public Roles GetByDescrip(string descrip)
        {
            return dataProvider.Roles.FirstOrDefault(rol => rol.Descrip == descrip);
        }

        public async void PostRol(Roles rol)
        {
            await dataProvider.Roles.AddAsync(rol);
        }

        public void PutRol(Roles rol)
        {
            Roles item = GetById(rol.Id);

            if (item != null)
            {
                item.Descrip = rol.Descrip;
                item.NivelAcceso = item.NivelAcceso;
            }
        }

        public void DeleteRol(Roles rol)
        {
            if (dataProvider.Roles.Any(r => r.Id == rol.Id))
            {
                dataProvider.Roles.Remove(rol);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }

        public Task<List<Roles>> GetAllAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return dataProvider.Roles.ToList();
            });
        }
    }
}