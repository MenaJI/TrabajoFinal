using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IAlumnosServices : IBaseServices<Alumnos>
    {
        Alumnos Insert(AlumnosModel model);
        List<AlumnosModel> GetAll();
    }
}
