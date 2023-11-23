using Microsoft.EntityFrameworkCore;
using PruebaDVP.Domain.Personas;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Infra.Persistence.SQLSever.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
