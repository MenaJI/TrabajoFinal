using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
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

            var InscripcionesMateria = Get(x => x.Fk_Alumno == alumno.Id,"Curso,Condicion").ToList();
            
            if (!InscripcionesMateria.Any() || InscripcionesMateria == null)
                return null;

            foreach(var inscripcion in InscripcionesMateria){
                inscripcion.Alumno = alumno;
                inscripcion.Curso = dataProvider.Cursos.Include("Materia").Include("CondicionCurso").Include("Formato").Include("Aula").FirstOrDefault(x => x.Id == inscripcion.Fk_Curso);
                inscripcion.Curso.Modulos = new List<Modulos>();
                var modulos = inscripcion.Curso.ModulosId.Split(',').ToList();
                modulos.ForEach(x => {
                    Modulos modulo = null;
                    if (!string.IsNullOrEmpty(x))
                        modulo = modulosService.Get(m => m.Id == Int32.Parse(x),"Dia,Horario").FirstOrDefault();
                    
                    if (modulo != null)
                        inscripcion.Curso.Modulos.Add(modulo);
                });

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