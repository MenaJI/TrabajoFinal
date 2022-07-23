using System;
using System.Collections.Generic;
using System.Linq;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Models;
using ApiREST.Services;


namespace ApiREST.ServicesImp
{
    public class CursosServices : BaseServicesImp<Cursos>, ICursosServices
    {
        public SecurityDbContext dataProvider;
        private readonly IAlumnosServices alumnosServices;
        private readonly IFormatosService formatosService;
        private readonly ICondicionesCursoService condicionesCursoService;
        private readonly IInscripcionCarreraService inscripcionCarreraService;
        private readonly IInscripcionesMateriaService inscripcionesMateriaService;
        private readonly IMateriasService materiasService;
        private readonly IAniosService aniosService;

        public CursosServices(SecurityDbContext context, IAlumnosServices _alumnoService,
        IInscripcionCarreraService _inscripcionCarreraService,
        IInscripcionesMateriaService _inscripcionesMateriaService,
        IMateriasService _materiasService,
        ICondicionesCursoService _condicionesCursoService,
        IFormatosService _formatoService,
        IAniosService _anioService) : base(context)
        {
            alumnosServices = _alumnoService;
            inscripcionCarreraService = _inscripcionCarreraService;
            inscripcionesMateriaService = _inscripcionesMateriaService;
            condicionesCursoService = _condicionesCursoService;
            formatosService = _formatoService;
            materiasService = _materiasService;
            aniosService = _anioService;
            dataProvider = context;
        }

        // public List<Cursos> ObtenerCursosDisponibles(string username)
        // {
        //     List<InscripcionesMateria> listaDeInscripcionesPosibles = new List<InscripcionesMateria>();
        //     List<Cursos> CursosHabilitadosParaCursar = new List<Cursos>();
        //     var alumno = alumnosServices.Get(a => a.NombreUsuario == username, "TipoDoc,Genero,Localidad,InscripcionCarreras,Nacionalidad,EstadoCivil").FirstOrDefault();

        //     if (alumno == null)
        //         return null;

        //     var inscripcionesMateriasPrevias = inscripcionesMateriaService.Get(m => m.Fk_Alumno == alumno.Id, "Curso,Materias,Alumno,Condicion");

        //     // Filtrar primero por las inscripciones a carrera que tenga el Alumno, que este activo 
        //     // y la fecha (tiene que traer los cursos del respectivo año).
        //     var cursosPosibles = Get(curso => alumno.InscripcionCarreras.Any(carrera => carrera.Fk_Carrera == curso.Materia.Fk_Carrera && carrera.Estado == "CONFIRMADA" && carrera.DeLegado == false)
        //     && curso.FechaFin.Year > DateTime.Now.Year && curso.Activa == true, "Formato,Aula,Materia,CondicionCurso");

        //     if (cursosPosibles == null)
        //         return null;

        //     foreach (var curso in cursosPosibles)
        //     {
        //         if (inscripcionesMateriasPrevias.Any(i => i.Fk_Curso == curso.Id && (i.Estado != "ANULADA" && i.Estado != "RECHAZADA")))
        //             continue;

        //         if (string.IsNullOrEmpty(curso.Materia.MateriasCorrelativas))
        //         {
        //             CursosHabilitadosParaCursar.Add(curso);
        //             continue;
        //         }

        //         var MateriasCorrelativas = curso.Materia.MateriasCorrelativas.Split(',').ToList();
        //         var habilitadoParaCursar = true;

        //         foreach (var materia in MateriasCorrelativas)
        //         {
        //             if (string.IsNullOrEmpty(materia))
        //                 continue;

        //             var inscripcion = inscripcionesMateriasPrevias.FirstOrDefault(i => i.Fk_Condicion == 3 && i.Materias.Id == Int32.Parse(materia));
        //             if (inscripcion == null)
        //             {
        //                 habilitadoParaCursar = false;
        //                 break;
        //             }
        //         }

        //         if (habilitadoParaCursar == true)
        //             CursosHabilitadosParaCursar.Add(curso);
        //     }

        //     foreach (var curso in CursosHabilitadosParaCursar)
        //     {
        //         curso.Materia = materiasService.GetByID(curso.Fk_Materia);
        //         curso.Materia.Anio = aniosService.GetByID(curso.Materia.Fk_Anio);
        //         curso.CondicionCurso = condicionesCursoService.GetByID(curso.Fk_CondicionCurso);
        //         curso.Formato = formatosService.GetByID(curso.Fk_Formato);
        //     }

        //     return CursosHabilitadosParaCursar;
        // }

        // Inscribe automaticamente a todas las materias de primer año de la 
        public void InscripcionesAutomaticasPrimerAño(Alumnos alumno, Carreras carrera)
        {
            var listaCursadoPrimerAnio = Get(c => c.FechaInicio.Year == DateTime.Now.Year && c.Anio == 1, "Materia");
            var condicion = dataProvider.Condiciones.FirstOrDefault(c => c.Descrip == "REGULAR");
            foreach (var curso in listaCursadoPrimerAnio){
                dataProvider.InscripcionesMateria.Add(
                    new InscripcionesMateria(){
                        Alumno = alumno,
                        Materias = curso.Materia,
                        Curso = curso,
                        Fecha = DateTime.Now,
                        Estado = "CONFIRMADA",
                    }
                );
            }
        }

        public InscripcionesMateria RealizarInscripcion(int cursoId, string username)
        {
            var alumno = alumnosServices.Get(a => a.NombreUsuario == username, "").FirstOrDefault();
            var curso = Get(c => c.Id == cursoId, "Materia").FirstOrDefault();
            var condicion = dataProvider.Condiciones.FirstOrDefault( condicion => condicion.Descrip == "REGULAR");


            var nuevaInscripcion = new InscripcionesMateria(){
                Alumno = alumno,
                Curso = curso,
                Fecha = DateTime.Now,
                Activo = true,
                Estado = "PENDIENTE",
                Materias = curso.Materia,
            };

            dataProvider.InscripcionesMateria.Add(nuevaInscripcion);
            dataProvider.SaveChanges();

            return nuevaInscripcion;
        }

        public List<Cursos> ObtenerCursosByFiltro(CursosFilterModel model)
        {
            var cursos = Get("Formato,Aula,Materia,CondicionCurso").ToList();

            cursos.ForEach( x => {
                x.Materia = materiasService.Get(m => m.Id == x.Fk_Materia,"Anio,Regimen,Campo,Carrera").FirstOrDefault();
            });



            return cursos.Where(x => x.Materia.Carrera.Id == model.carrera.Id && x.Materia.Anio.Id == model.anio.Id).ToList();
        }
    }
}