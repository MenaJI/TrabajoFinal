using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class CamposService : ICamposService
    {
        public SecurityDbContext dataProvider;

        public CamposService(SecurityDbContext appDbContext) { dataProvider = appDbContext; }

        public List<Campos> GetAll()
        {
            return dataProvider.Campos.ToList();
        }

        public Campos GetById(int id)
        {
            return dataProvider.Campos.FirstOrDefault(x => x.Id == id);
        }

        public Campos GetByDescrip(string descrip)
        {
            return dataProvider.Campos.FirstOrDefault(x => x.Descrip == descrip);
        }

        public async void PostCampos(Campos campo)
        {
            await dataProvider.Campos.AddAsync(campo);
        }

        public void PutCampos(Campos campo)
        {
            Campos item = GetById(campo.Id);

            if (item != null)
            {
                item.Descrip = campo.Descrip;
            }
        }

        public void DeleteCampos(Campos campo)
        {
            if (dataProvider.Campos.Any(r => r.Id == campo.Id))
            {
                dataProvider.Campos.Remove(campo);
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}