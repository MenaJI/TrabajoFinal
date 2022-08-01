using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.ServicesImp
{
    public class AlumnosService : BaseServicesImp<Alumnos>, IAlumnosServices
    {
        private readonly SecurityDbContext dataProvider;
        // private readonly UserManager<Usuarios> userManager;
        // private readonly RoleManager<IdentityRole> roleManager;
        
        public AlumnosService(SecurityDbContext context) : base(context)
        {
            dataProvider = context;
        }

        public Alumnos Insert(AlumnosModel model)
        {
            try
            {
                Alumnos alumno;

                alumno = Get(a => a.NombreUsuario == model.NombreUsuario, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
                
                if (alumno != null)
                {
                    alumno.Nombre = model.Nombre;
                    alumno.Apellido = model.Apellido;
                    alumno.TipoDoc = dataProvider.TiposDocs.FirstOrDefault(td => td.Descrip == model.TipoDocumento);
                    alumno.NroDocumento = model.NumeroDocumento;
                    alumno.Genero = dataProvider.Generos.FirstOrDefault(g => g.Descrip == model.Genero);
                    alumno.Localidad = dataProvider.Localidades.FirstOrDefault(l => l.Descrip == model.Localidad);
                    alumno.Nacionalidad = dataProvider.Nacionalidades.FirstOrDefault(n => n.Descrip == model.Nacionalidad);
                    alumno.EstadoCivil = dataProvider.EstadosCiviles.FirstOrDefault(ec => ec.Descrip == model.EstadoCivil);
                    alumno.NombreUsuario = model.NombreUsuario;
                    alumno.Discapacidad = model.Discapacidad;
                    alumno.TipoDiscapacidad = model.DiscapacidadDescripcion;
                    alumno.DireccionDomicilio = model.Domicilio != null ? new Direcciones(){
                        Calle = model.Domicilio.Calle,
                        Numero = model.Domicilio.Numero,
                        Departamento = model.Domicilio.Dpto,
                        Piso = model.Domicilio.Piso,
                        Telefono = model.Domicilio.Telefono,
                        Localidad = dataProvider.Localidades.FirstOrDefault(x => x.Descrip == model.Domicilio.Localidad),
                    } : null;
                    alumno.DireccionOcupacion = model.Domicilio != null ? new Direcciones(){
                        Calle = model.OcupacionDireccion.Calle,
                        Numero = model.OcupacionDireccion.Numero,
                        Departamento = model.OcupacionDireccion.Dpto,
                        Piso = model.OcupacionDireccion.Piso,
                        Telefono = model.OcupacionDireccion.Telefono,
                        Localidad = dataProvider.Localidades.FirstOrDefault(x => x.Descrip == model.OcupacionDireccion.Localidad),
                    } : null;
                    alumno.PuebloOriginario = model.PuebloOriginario;
                    alumno.Etnia = model.Etnia;
                    alumno.Comunidad = model.Comunidad;
                    alumno.PaisNacimiento = dataProvider.Paises.FirstOrDefault(x => x.Descripcion == model.PaisNacimiento);
                    Update(alumno);
                }
                else
                {
                    Insert(MapearAlumno(model));
                }

                return alumno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AlumnosModel> GetAll()
        {
            var listAlumnos = Get("TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil,PaisNacimiento,DireccionOcupacion,DireccionDomicilio");

            var result = new List<AlumnosModel>();

            foreach (var alumno in listAlumnos)
            {
                result.Add(MapearAlumnoModel(alumno));
            }

            return result;
        }

        public AlumnosModel MapearAlumnoModel(Alumnos alumno)
        {
            Direcciones domicilioDireccion = null;
            if (alumno.DireccionDomicilio != null)
                domicilioDireccion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionDomicilio.Id);
            
            Direcciones ocupacionDireccion = null;
            if (alumno.DireccionOcupacion != null)
                ocupacionDireccion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionOcupacion.Id);

            var alumnoModel = new AlumnosModel()
            {
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                TipoDocumento = alumno.TipoDoc.Descrip,
                NumeroDocumento = alumno.NroDocumento,
                Genero = alumno.Genero.Descrip,
                Localidad = alumno.Localidad.Descrip,
                Nacionalidad = alumno.Nacionalidad.Descrip,
                EstadoCivil = alumno.EstadoCivil.Descrip,
                NombreUsuario = alumno.NombreUsuario,
                Domicilio = domicilioDireccion != null ? new DireccionesModel(){
                    Id = domicilioDireccion.Id,
                    Calle = domicilioDireccion.Calle,
                    Numero = domicilioDireccion.Numero,
                    Piso = domicilioDireccion.Piso,
                    Dpto = domicilioDireccion.Departamento,
                    Localidad = domicilioDireccion.Localidad != null ? domicilioDireccion.Localidad.Descrip : null,
                    Telefono = domicilioDireccion.Telefono
                } : null,
                Ocupacion = !string.IsNullOrEmpty(alumno.Ocupacion) ? alumno.Ocupacion : "",
                OcupacionDireccion = ocupacionDireccion != null ? new DireccionesModel(){
                    Id = ocupacionDireccion.Id,
                    Calle = ocupacionDireccion.Calle,
                    Numero = ocupacionDireccion.Numero,
                    Piso = ocupacionDireccion.Piso,
                    Dpto = ocupacionDireccion.Departamento,
                    Localidad = ocupacionDireccion.Localidad != null ? ocupacionDireccion.Localidad.Descrip : null,
                    Telefono = ocupacionDireccion.Telefono
                } : null,
                PaisNacimiento = alumno.PaisNacimiento != null ? alumno.PaisNacimiento.Descripcion : "",
                Discapacidad = alumno.Discapacidad,
                DiscapacidadDescripcion = alumno.TipoDiscapacidad,
                PuebloOriginario = alumno.PuebloOriginario,
                Etnia = !string.IsNullOrEmpty(alumno.Etnia) ? alumno.Etnia : "",
                Comunidad = !string.IsNullOrEmpty(alumno.Comunidad) ? alumno.Comunidad : "",
                InscripcionesCarrera = alumno.InscripcionCarreras.ToList()
            };

            return alumnoModel;
        }

        public Alumnos MapearAlumno(AlumnosModel model)
        {
            var result = new Alumnos()
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                TipoDoc = dataProvider.TiposDocs.FirstOrDefault(td => td.Descrip == model.TipoDocumento),
                NroDocumento = model.NumeroDocumento,
                Genero = dataProvider.Generos.FirstOrDefault(g => g.Descrip == model.Genero),
                Localidad = dataProvider.Localidades.FirstOrDefault(l => l.Descrip == model.Localidad),
                Nacionalidad = dataProvider.Nacionalidades.FirstOrDefault(n => n.Descrip == model.Nacionalidad),
                EstadoCivil = dataProvider.EstadosCiviles.FirstOrDefault(ec => ec.Descrip == model.EstadoCivil),
                NombreUsuario = model.NombreUsuario,
                DireccionDomicilio = new Direcciones(){
                    Calle = !string.IsNullOrEmpty(model.Domicilio.Calle) ? model.Domicilio.Calle : null,
                    Numero = !string.IsNullOrEmpty(model.Domicilio.Numero) ? model.Domicilio.Numero : null,
                    Localidad = !string.IsNullOrEmpty(model.Domicilio.Localidad) ? dataProvider.Localidades.FirstOrDefault(l => l.Descrip == model.Domicilio.Localidad) : null,
                    Departamento = !string.IsNullOrEmpty(model.Domicilio.Dpto) ? model.Domicilio.Dpto : null,
                    Telefono = !string.IsNullOrEmpty(model.Domicilio.Telefono) ? model.Domicilio.Telefono : null,
                    Piso = !string.IsNullOrEmpty(model.Domicilio.Piso) ? model.Domicilio.Piso : null,
                },
                Ocupacion = model.Ocupacion,
                DireccionOcupacion = new Direcciones(){
                    Calle = !string.IsNullOrEmpty(model.OcupacionDireccion.Calle) ? model.OcupacionDireccion.Calle : null,
                    Numero = !string.IsNullOrEmpty(model.OcupacionDireccion.Numero) ? model.OcupacionDireccion.Numero : null,
                    Localidad = !string.IsNullOrEmpty(model.OcupacionDireccion.Localidad) ? dataProvider.Localidades.FirstOrDefault(l => l.Descrip == model.Domicilio.Localidad) : null,
                    Departamento = !string.IsNullOrEmpty(model.OcupacionDireccion.Dpto) ? model.OcupacionDireccion.Dpto : null,
                    Telefono = !string.IsNullOrEmpty(model.OcupacionDireccion.Telefono) ? model.OcupacionDireccion.Telefono : null,
                    Piso = !string.IsNullOrEmpty(model.OcupacionDireccion.Piso) ? model.OcupacionDireccion.Piso : null,
                },
                PuebloOriginario = model.PuebloOriginario,
                Etnia = model.Etnia,
                Comunidad = model.Comunidad,
                Discapacidad = model.Discapacidad,
                TipoDiscapacidad = model.DiscapacidadDescripcion,
                PaisNacimiento = dataProvider.Paises.FirstOrDefault(x => x.Descripcion == model.PaisNacimiento)
            };

            return result;
        }

        public Response VerificarDatosAlumnos(string userName)
        {
            var alumno = Get(x => x.NombreUsuario == userName,"TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            
            if (alumno == null || ValidarAlumno(alumno))
                return new Response(){Status = "Error", Message ="Datos Personales - No validos"};

            return new Response(){Status = "Ok", Message ="Datos Personales - Validos"};    
        }

        private bool ValidarAlumno(Alumnos alumno)
        {
            if (string.IsNullOrEmpty(alumno.Nombre) ||
                string.IsNullOrEmpty(alumno.Apellido) ||
                alumno.NroDocumento != 0)
                return false;
            
            return true;
        }
    }
}