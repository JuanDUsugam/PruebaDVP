using MediatR;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioByNombreUsuario
{
    public class GetUsuarioByNombreUsuarioQuery : IRequest<Usuario>
    {
        public string? NombreUsuario { get; set; }
    }
}
