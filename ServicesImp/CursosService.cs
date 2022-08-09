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
        private readonly IInscripcionCarreraService inscripcionCarreraService;
        private readonly IInscripcionesMateriaService inscripcionesMateriaService;
        private readonly IMateriasService materiasService;
        private readonly IAniosService aniosService;

        public CursosServices(SecurityDbContext context, IAlumnosServices _alumnoService,
        IInscripcionCarreraService _inscripcionCarreraService,
        IInscripcionesMateriaService _inscripcionesMateriaService,
        IMateriasService _materiasService,
        IFormatosService _formatoService,
        IAniosService _anioService) : base(context)
        {
            alumnosServices = _alumnoService;
            inscripcionCarreraService = _inscripcionCarreraService;
            inscripcionesMateriaService = _inscripcionesMateriaService;
            formatosService = _formatoService;
            materiasService = _materiasService;
            aniosService = _anioService;
            dataProvider = context;
        }



        // Inscribe automaticamente a todas las materias de primer año de la 
        public void InscripcionesAutomaticasPrimerAño(Alumnos alumno, Carreras carrera)
        {
            var listaCursadoPrimerAnio = Get(c => c.FechaInicio.Year == DateTime.Now.Year, "Materia");
            // var condicion = dataProvider.Condiciones.FirstOrDefault(c => c.Descrip == "REGULAR");
            foreach (var curso in listaCursadoPrimerAnio.Where(x => x.Materia.Fk_Anio == 1))
            {
                dataProvider.InscripcionesMateria.Add(
                    new InscripcionesMateria()
                    {
                        Alumno = alumno,
                        Materias = curso.Materia,
                        Curso = curso,
                        Fecha = DateTime.Now,
                        Estado = "CONFIRMADA",
                    }
                );
                dataProvider.SaveChanges();
            }
        }

        public List<Cursos> ObtenerCursosByFiltro(CursosFilterModel model)
        {
            var cursos = Get("Formato,Aula,Materia").ToList();

            cursos.ForEach(x =>
            {
                x.Materia = materiasService.Get(m => m.Id == x.Fk_Materia, "Anio,Regimen,Campo,Carrera").FirstOrDefault();
                x.Docentes = new List<Docentes>();
                var docentes = x.DocentesId.Split(',').ToList();
                foreach (var docente in docentes)
                {
                    if (!string.IsNullOrEmpty(docente) && Int32.TryParse(docente, out var result))
                        x.Docentes.Add(dataProvider.Docentes.FirstOrDefault(x => x.Id == result));
                }
            });



            return cursos.Where(x => x.Materia.Carrera.Id == model.carrera.Id && x.Materia.Anio.Id == model.anio.Id).ToList();
        }
    }
}