using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.Models;

namespace ApiREST.ServicesImp
{
    public class InscripcionCarreraService : BaseServicesImp<InscripcionCarrera>, IInscripcionCarreraService
    {
        private readonly SecurityDbContext dataProvider;
        private readonly IAlumnosServices alumnosServices;
        
        public InscripcionCarreraService(SecurityDbContext context, IAlumnosServices _alumnosServices) : base(context)
        {
            dataProvider = context;
            alumnosServices = _alumnosServices;
        }

        public DetalleInscripcionCarrera ObtenerDetallesInscripcionCarrera(int IdInscripcion){
            
            DetalleInscripcionCarrera result = null;

            var alumno = alumnosServices.Get(a => a.InscripcionCarreras.Any(i => i.Id == IdInscripcion), "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            if (alumno != null)
                result = new DetalleInscripcionCarrera(){
                    UserNameAlumno = alumno.NombreUsuario,
                    NombreAlumno = alumno.Nombre,
                    ApellidoAlumno = alumno.Apellido,
                    NumeroDocumento = alumno.NroDocumento.ToString(),
                    TipoDocumento = alumno.TipoDoc.Descrip,
                    GeneroAlumno = alumno.Genero.Descrip,
                    Localidad = alumno.Localidad.Descrip,
                    EstadoCivil = alumno.EstadoCivil.Descrip,
                    Nacionalidad = alumno.Nacionalidad.Descrip,
                };

            return result;
        }
    }
}