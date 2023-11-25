using Microsoft.EntityFrameworkCore;
using PruebaDVP.Domain.Common;
using PruebaDVP.Domain.Personas;
using PruebaDVP.Domain.Usuarios;
using PruebaDVP.Infra.Persistence.SQLSever.Configurations;

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
            ModelConfig(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase<string>>())
            {
                switch (entry.State)
                {
                    
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }
        private void ModelConfig(ModelBuilder builder)
        {
            new UsuarioConfig(builder.Entity<Usuario>());
            new PersonaConfig(builder.Entity<Persona>());
        }
    }
}
