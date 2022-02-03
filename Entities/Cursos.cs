using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ApiREST.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiREST.Entities
{
    public class Cursos : BaseEntity
    {
        public string Descrip { get; set; }

        public bool Activa { get; set; }
        public int Cupos { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        [ForeignKey("Materia")]
        public int Fk_Materia { get; set; }
        public Materias Materia { get; set; }

        [ForeignKey("CondicionCurso")]
        public int Fk_CondicionCurso { get; set; }
        public CondicionesCurso CondicionCurso { get; set; }

        [ForeignKey("Formato")]
        public int Fk_Formato { get; set; }
        public Formatos Formato { get; set; }

        [ForeignKey("Aula")]
        public int Fk_Aula { get; set; }
        public Aulas Aula { get; set; }

        public string DocentesId { get; set; }
        public string ModulosId { get; set; }

        [NotMapped]
        public List<Docentes> Docentes { get; set; }
        [NotMapped]
        public virtual List<Modulos> Modulos { get; set; }

    }
}