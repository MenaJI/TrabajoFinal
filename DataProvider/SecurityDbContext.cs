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

    }
}