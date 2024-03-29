using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using ApiREST.Models;
using Microsoft.EntityFrameworkCore;

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

        public DetalleInscripcionCarrera ObtenerDetallesInscripcionCarrera(int IdInscripcion)
        {

            DetalleInscripcionCarrera result = null;

            var alumno = alumnosServices.Get(a => a.InscripcionCarreras.Any(i => i.Id == IdInscripcion), "TipoDoc,DireccionOcupacion,DireccionDomicilio,PaisNacimiento,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil,").FirstOrDefault();
            var direccion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionDomicilio.Id);
            var ocupacion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionOcupacion.Id);

            if (alumno != null)
                result = new DetalleInscripcionCarrera()
                {
                    UserNameAlumno = alumno.NombreUsuario,
                    NombreAlumno = alumno.Nombre,
                    ApellidoAlumno = alumno.Apellido,
                    NumeroDocumento = alumno.NroDocumento.ToString(),
                    TipoDocumento = alumno.TipoDoc.Descrip,
                    GeneroAlumno = alumno.Genero.Descrip,
                    Localidad = alumno.Localidad.Descrip,
                    EstadoCivil = alumno.EstadoCivil.Descrip,
                    Nacionalidad = alumno.Nacionalidad.Descrip,
                    PaisDeNacimiento = alumno.PaisNacimiento.Descripcion,
                    DomicilioCalle = direccion.Calle != null ? direccion.Calle : "",
                    DomicilioNumero = direccion.Numero != null ? direccion.Numero : "",
                    DomicilioLocalidad = direccion.Localidad != null ? direccion.Localidad.Descrip : "",
                    DomicilioDepartamento = direccion.Departamento != null ? direccion.Departamento : "",
                    DomicilioPiso = direccion.Piso != null ? direccion.Piso : "",
                    DomicilioTelefono = direccion.Telefono != null ? direccion.Telefono : "",
                    Discapacidad = alumno.Discapacidad,
                    DiscapacidadDescripcion = alumno.TipoDiscapacidad,
                    OcupacionCalle = ocupacion.Calle != null ? ocupacion.Calle : "",
                    OcupacionDepartamento = ocupacion.Departamento != null ? ocupacion.Departamento : "",
                    OcupacionLocalidad = ocupacion.Localidad != null ? ocupacion.Localidad.Descrip : "",
                    OcupacionNumero = ocupacion.Numero != null ? ocupacion.Numero : "",
                    OcupacionPiso = ocupacion.Piso != null ? ocupacion.Piso : "",
                    OcupacionTelefono = ocupacion.Telefono != null ? ocupacion.Telefono : "",
                    PuebloOriginario = alumno.PuebloOriginario,
                    Etnia = alumno.Etnia,
                    Comunidad = alumno.Comunidad,
                };

            return result;
        }
    }
}