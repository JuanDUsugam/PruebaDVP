using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaDVP.Domain.Personas;

namespace PruebaDVP.Infra.Persistence.SQLSever.Configurations
{
    public class PersonaConfig
    {
        public PersonaConfig(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(p => p.Identificador);
            builder.Property(p => p.Nombres).HasMaxLength(25);
            builder.Property(p => p.Apellidos).HasMaxLength(40);
            builder.Property(p => p.NumeroIdentificacion);
            builder.Property(p => p.Email).HasMaxLength(30);
            builder.Property(p => p.TipoIdentificacion).HasMaxLength(15);
            builder.HasOne(P => P.Usuario).WithOne();
        }   
    }
}
