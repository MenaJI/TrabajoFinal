using ApiREST.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.Services
{
    public interface ISecurityDbContext
    {
        int SaveChanges();

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<TiposDocs> TiposDocs { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Dias> Dias { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<InscripcionCarrera> InscripcionCarreras { get; set; }
        public DbSet<Anios> Anios { get; set; }
    }
}