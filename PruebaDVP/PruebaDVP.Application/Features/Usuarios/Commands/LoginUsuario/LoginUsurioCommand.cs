using MediatR;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;

namespace PruebaDVP.Application.Features.Usuarios.Commands.LoginUsuario
{
    public class LoginUsurioCommand :IRequest<UsuarioLoginResponseDto>
    {
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
    }
}
