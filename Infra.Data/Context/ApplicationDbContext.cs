using Domain.Login.Entities;
using Domain.Usuario.Entidades;
using Infra.Data.EntityConfigurations.Usuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
            {
            }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Usuario;Username=postgres;Password=Fern@nd01331");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
