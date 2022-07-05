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
                    Update(alumno);
                }
                else
                {
                    Insert(MapearAlumno(model));
                }

                return alumno;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AlumnosModel> GetAll()
        {
            var listAlumnos = Get("TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil");

            var result = new List<AlumnosModel>();

            foreach (var alumno in listAlumnos)
            {
                result.Add(MapearAlumnoModel(alumno));
            }

            return result;
        }

        public AlumnosModel MapearAlumnoModel(Alumnos alumno)
        {
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
                NombreUsuario = model.NombreUsuario
            };

            return result;
        }

        public ValidacionResponse VerificarDatosAlumnos(string userName)
        {
            var alumno = Get(x => x.NombreUsuario == userName,"TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            var validacion = new ValidacionResponse();
            if (alumno == null || !ValidarAlumno(alumno))
                return validacion;
            
            if (!alumno.InscripcionCarreras.Any())
                return validacion;

            var archivos = dataProvider.Archivos.Where(x => x.AlumnoUserName == userName);

            if (archivos.Any( x => x.TipoArchivo == ""))
                return validacion;

            if (archivos.Any( x => x.TipoArchivo == ""))
                return validacion;

            if (archivos.Any( x => x.TipoArchivo == ""))
                return validacion;

            return validacion;    
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