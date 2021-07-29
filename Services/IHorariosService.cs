using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Services
{
    public interface IHorariosService
    {
        List<Horarios> GetAll();
        Horarios GetById(int id);
        Horarios GetByDescrip(string descrip);
        void PostHorarios(Horarios horario);
        void PutHorarios(Horarios horario);
        void DeleteHorarios(Horarios horario);
        void SaveChanges();
    }
}