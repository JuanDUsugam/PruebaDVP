using MediatR;

namespace PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<string>
    {
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
    }
}
