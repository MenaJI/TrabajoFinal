using System;
using System.Collections.Generic;
using ApiREST.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.DataProvider
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        /* DbSets */
        public DbSet<Roles> Roles { get; set; }

        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }

        public DbSet<Generos> Generos { get; set; }

        public DbSet<Localidades> Localidades { get; set; }

        public DbSet<Nacionalidades> Nacionalidades { get; set; }

        public DbSet<TiposDocs> TiposDocs { get; set; }
    }
}