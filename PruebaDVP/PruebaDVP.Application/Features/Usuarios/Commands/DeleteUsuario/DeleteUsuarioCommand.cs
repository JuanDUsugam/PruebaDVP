using MediatR;

namespace PruebaDVP.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand :IRequest<string>
    {
        public string? Identificador { get; set; }
    }
}
