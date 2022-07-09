using System;
using ApiREST.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.DataProvider
{
    public class SecurityDbContext : IdentityDbContext<Usuarios>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<InscripcionesMateria>().HasOne(i => i.Materias).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);

        }

        /* DbSets */
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<TiposDocs> TiposDocs { get; set; }
        public DbSet<Condiciones> Condiciones { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Dias> Dias { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<InscripcionCarrera> InscripcionCarreras { get; set; }
        public DbSet<Anios> Anios { get; set; }
        public DbSet<Regimenes> Regimenes { get; set; }
        public DbSet<Campos> Campos { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<CondicionesCurso> CondicionesCurso { get; set; }
        public DbSet<Formatos> Formatos { get; set; }
        public DbSet<InscripcionesMateria> InscripcionesMateria { get; set; }
        public DbSet<Archivos> Archivos { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Materias> Materias { get;set; }
    }
}