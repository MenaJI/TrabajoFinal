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
        public DbSet<Alumnos> Alumno { get; set; }
        public DbSet<Carreras> Carrera { get; set; }
        public DbSet<InscripcionCarrera> InscripcionCarrera { get; set; }
    }
}