using MediatR;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;

namespace PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<UsuarioLoginResponseDto>
    {
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
    }
}
