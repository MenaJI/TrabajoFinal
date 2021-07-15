using System;
using System.Collections.Generic;
using ApiREST.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.DataProvider
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext (DbContextOptions options):base(options){}
        protected override void OnModelCreating ( ModelBuilder modelBuilder ) {}

        /* DbSets */
        public DbSet<Roles> Roles { get; set; }
    }
}