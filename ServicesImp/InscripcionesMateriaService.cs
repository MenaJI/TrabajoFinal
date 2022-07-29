using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.ServicesImp
{
    public class InscripcionesMateriaService : BaseServicesImp<InscripcionesMateria>, IInscripcionesMateriaService
    {
        private readonly SecurityDbContext dataProvider;
        private readonly IAlumnosServices alumnosServices;
        private readonly IModulosService modulosService;
        private readonly IDocentesServices docentesServices;

        public InscripcionesMateriaService(SecurityDbContext context, 
        IAlumnosServices _alumnosService,
        IModulosService _modulosService,
        IDocentesServices _docentesServices) : base(context)
        {
            dataProvider = context;
            alumnosServices = _alumnosService;
            modulosService = _modulosService;
            docentesServices = _docentesServices;
        }

        public List<InscripcionesMateria> GetByUserName(string username)
        {
            var alumno = alumnosServices.Get(a => a.NombreUsuario == username,"TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno == null)
                return null;

            var InscripcionesMateria = Get(x => x.Fk_Alumno == alumno.Id,"Curso").ToList();
            
            if (!InscripcionesMateria.Any() || InscripcionesMateria == null)
                return null;

            foreach(var inscripcion in InscripcionesMateria){
                inscripcion.Alumno = alumno;
                inscripcion.Curso = dataProvider.Cursos.Include("Materia").Include("Formato").Include("Aula").FirstOrDefault(x => x.Id == inscripcion.Fk_Curso);
                inscripcion.Curso.Modulos = new List<Modulos>();
                var modulos = inscripcion.Curso.ModulosId.Split(',').ToList();
                modulos.ForEach(x => {
                    Modulos modulo = null;
                    if (!string.IsNullOrEmpty(x))
                        modulo = modulosService.Get(m => m.Id == Int32.Parse(x),"Dia,Horario").FirstOrDefault();
                    
                    if (modulo != null)
                        inscripcion.Curso.Modulos.Add(modulo);
                });

                inscripcion.Curso.Materia = dataProvider.Materias.Include("Anio").Include("Regimen").Include("Campo").Include("Carrera").FirstOrDefault(x => x.Id == inscripcion.Curso.Fk_Materia);

                var docentes = inscripcion.Curso.DocentesId.Split(',').ToList();
                inscripcion.Curso.Docentes = new List<Docentes>();
                modulos.ForEach(x => {
                    Docentes docente = null;
                    if (!string.IsNullOrEmpty(x))
                        docente = docentesServices.Get(d => d.Id == Int32.Parse(x),"").FirstOrDefault();

                    if (docente != null)
                        inscripcion.Curso.Docentes.Add(docente);
                });
            }
                

            return InscripcionesMateria;
        }

        public DetalleInscripcionMateriaModel GetDetalleInscripcion(int id)
        {
            DetalleInscripcionMateriaModel result = null;
            var materiasCorrelativas = new List<string>();
            var inscripcion = Get(i => i.Id == id, "Curso,Materias,Alumno").FirstOrDefault();

            if (inscripcion == null)
                return null;

            var alumno = alumnosServices.Get(x => x.Id == inscripcion.Fk_Alumno, "TipoDoc,DireccionOcupacion,DireccionDomicilio,PaisNacimiento,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();
            if (alumno == null)
                return null;

            var direccion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionDomicilio.Id);
            var ocupacion = dataProvider.Direcciones.Include("Localidad").FirstOrDefault(x => x.Id == alumno.DireccionOcupacion.Id);
            var materia = dataProvider.Materias.Include("Anio").Include("Regimen").Include("Campo").Include("Carrera").FirstOrDefault(x => x.Id == inscripcion.Materias.Id);
            if (materia == null)
                return null;

            materia.MateriasCorrelativas.Split(',').ToList().ForEach(x => {
                if (Int32.TryParse(x, out var result))
                    materiasCorrelativas.Add(dataProvider.Materias.FirstOrDefault(m => m.Id == result).Descrip);
            });

            if (alumno != null)
                result = new DetalleInscripcionMateriaModel(){
                    UserNameAlumno = alumno.NombreUsuario,
                    NombreAlumno = alumno.Nombre,
                    ApellidoAlumno = alumno.Apellido,
                    NumeroDocumento = alumno.NroDocumento.ToString(),
                    TipoDocumento = alumno.TipoDoc.Descrip,
                    GeneroAlumno = alumno.Genero.Descrip,
                    Localidad = alumno.Localidad.Descrip,
                    EstadoCivil = alumno.EstadoCivil.Descrip,
                    Nacionalidad = alumno.Nacionalidad.Descrip,
                    CarreraNombre = materia.Carrera.Descripcion,
                    MateriasCorrelativas = materiasCorrelativas,
                    PaisDeNacimiento = alumno.PaisNacimiento.Descripcion,
                    DomicilioCalle = direccion.Calle,
                    DomicilioNumero = direccion.Numero,
                    DomicilioLocalidad = direccion.Localidad.Descrip,
                    DomicilioDepartamento = direccion.Departamento,
                    DomicilioPiso = direccion.Piso,
                    DomicilioTelefono = direccion.Telefono,
                    Discapacidad = alumno.Discapacidad,
                    DiscapacidadDescripcion = alumno.TipoDiscapacidad,
                    OcupacionCalle = ocupacion.Calle,
                    OcupacionDepartamento = ocupacion.Departamento,
                    OcupacionLocalidad = ocupacion.Localidad.Descrip,
                    OcupacionNumero = ocupacion.Numero,
                    OcupacionPiso = ocupacion.Piso,
                    OcupacionTelefono = ocupacion.Telefono,
                    PuebloOriginario = alumno.PuebloOriginario,
                    Etnia = alumno.Etnia,
                    Comunidad = alumno.Comunidad,
                };


            return result;
        }

        public List<InscripcionesMateria> ObtenerInscripcionesValidas(string username)
        {
            List<InscripcionesMateria> listaDeInscripcionesPosibles = new List<InscripcionesMateria>();
            var alumno = alumnosServices.Get(a => a.NombreUsuario == username, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

            if (alumno == null)
                return null;

            var inscripcionesMateriasPrevias = Get(m => m.Fk_Alumno == alumno.Id, "Curso,Materias,Alumno");

            return null;
        }
    }
}