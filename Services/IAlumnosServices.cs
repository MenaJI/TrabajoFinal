using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;

namespace ApiREST.Services
{
    public interface IAlumnosServices : IBaseServices<Alumnos>
    {
        Alumnos Insert(AlumnosModel model);
        AlumnosModel MapearAlumnoModel(Alumnos model);
        List<AlumnosModel> GetAll();

        ValidacionResponse VerificarDatosAlumnos(string userName);
    }
}
