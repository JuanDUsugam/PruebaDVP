using MediatR;

namespace PruebaDVP.Application.Features.Usuarios.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
    }
}
