using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;

namespace ApiREST.ServicesImp
{
    public class InscripcionesMateriaService : BaseServicesImp<InscripcionesMateria>, IInscripcionesMateriaService
    {
        private readonly SecurityDbContext dataProvider;
        private readonly IAlumnosServices alumnosServices;

        public InscripcionesMateriaService(SecurityDbContext context, IAlumnosServices _alumnosService) : base(context)
        {
            dataProvider = context;
            alumnosServices = _alumnosService;
        }

        public List<InscripcionesMateria> ObtenerInscripcionesValidas(string username)
        {
            List<InscripcionesMateria> listaDeInscripcionesPosibles = new List<InscripcionesMateria>();
            var alumno = alumnosServices.Get(a => a.NombreUsuario == username, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno == null)
                return null;

            var inscripcionesMateriasPrevias = Get(m => m.Fk_Alumno == alumno.Id, "Curso,Materias,Alumno,Condicion");

            return null;
        }
    }
}