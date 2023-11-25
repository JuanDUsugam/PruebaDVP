using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Application.Interfaces.Infrastructure.Identity
{
    public interface IJwtGenerator
    {
        string CreateToken(Usuario usuario);
    }
}
