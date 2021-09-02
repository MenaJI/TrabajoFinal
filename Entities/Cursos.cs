using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ApiREST.Entities;
using System;

namespace ApiRest.Entities
{
    public class Cursos
    {
        public int Id { get; set; }

        public string Descrip { get; set; }

        public bool Activa { get; set; }

        public int Cupos { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        [ForeignKey("Fk_Materia")] public int Fk_Materia { get; set; }
        public Materias Materia { get; set; }

        [ForeignKey("Fk_CondicionCurso")] public int Fk_CondicionCurso { get; set; }
        public CondicionesCurso CondicionCurso { get; set; }

        [ForeignKey("Fk_Formato")] public int Fk_Formato { get; set; }
        public Formatos Formato { get; set; }

        [ForeignKey("Fk_Aula")] public int Fk_Aula { get; set; }
        public Aulas Aula { get; set; }

        [ForeignKey("Fk_Docente1")] public int Fk_Docente1 { get; set; }
        public Docentes Docente1 { get; set; }

        [ForeignKey("Fk_Docente2")] public int Fk_Docente2 { get; set; }
        public Docentes Docente2 { get; set; }

        [ForeignKey("Fk_Docente3")] public int Fk_Docente3 { get; set; }
        public Docentes Docente3 { get; set; }

        public virtual ICollection<Modulos> Modulos { get; set; }







    }
}