using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionesMateriaService : IInscripcionesMateriaService
    {
        private readonly SecurityDbContext dataProvider;
        public InscripcionesMateriaService(SecurityDbContext dataProvider_)
        {
            dataProvider = dataProvider_;
        }

        public void DeleteInscripcionMateria(InscripcionesMateria _InscripcionesMateria)
        {
            var result = dataProvider.InscripcionesMateria.FirstOrDefault(a => a.Id == _InscripcionesMateria.Id);
            if (result != null)
            {
                dataProvider.InscripcionesMateria.Remove(result);
            }
        }

        public List<InscripcionesMateria> GetAll()
        {
            return dataProvider.InscripcionesMateria.ToList();
        }

        public void PostInscripcionMateria(InscripcionesMateria _InscripcionesMateria)
        {
            var result = dataProvider.InscripcionesMateria.FirstOrDefault(a => a.Id == _InscripcionesMateria.Id);
            if (result == null)
            {
                dataProvider.InscripcionesMateria.Add(result);
            }
        }

        public void PutInscripcionMateria(InscripcionesMateria _InscripcionesMateria)
        {
            var result = dataProvider.InscripcionesMateria.FirstOrDefault(a => a.Id == _InscripcionesMateria.Id);
            if (result != null)
            {
                result = _InscripcionesMateria;
            }
        }

        public void SaveChanges()
        {
            dataProvider.SaveChanges();
        }
    }
}