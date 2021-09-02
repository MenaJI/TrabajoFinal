using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionMateria : IInscripcionMateriaService
    {
        private readonly SecurityDbContext dataProvider;
        public InscripcionMateriaService(SecurityDbContext dataProvider_)
        {
            dataProvider = dataProvider_;
        }

        public void DeleteInscripcionMateria(InscripcionMateria inscripcionMateria)
        {
            var InscripcionMateria = dataProvider.InscripcionMateria.FirstOrDefault(a => a.Id == inscripcionMateria.Id);
            if (inscripcionMateria != null)
            {
                dataProvider.InscripcionCarreras.Remove(InscripcionMateria);
            }
        }

        public List<InscripcionMateria> GetAll()
        {
            return dataProvider.InscripcionCarreras.ToList();
        }

        public void PostInscripcionMateria(InscripcionMateria inscripcionMateria)
        {
            var result = dataProvider.InscripcionMateria.FirstOrDefault(a => a.Id == inscripcionMateria.Id);
            if (result == null)
            {
                dataProvider.inscripcionMateria.Add(result);
            }
        }

        public void PutInscripcionMateria(InscripcionMateria inscripcionMateria)
        {
            var result = dataProvider.InscripcionMateria.FirstOrDefault(a => a.Id == inscripcionMateria.Id);
            if (result != null)
            {
                result = inscripcionMateria;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}