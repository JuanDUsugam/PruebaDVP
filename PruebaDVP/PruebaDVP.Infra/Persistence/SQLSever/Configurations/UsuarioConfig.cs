using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Infra.Persistence.SQLSever.Configurations
{
    public class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Identificador);
            builder.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Pass).IsRequired().HasMaxLength(8);
        }
    }
}
