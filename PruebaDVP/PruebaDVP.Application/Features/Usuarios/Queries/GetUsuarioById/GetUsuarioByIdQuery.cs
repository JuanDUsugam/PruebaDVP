using MediatR;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;

namespace PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioResponseQuery>
    {
        public string? Id { get; set; }

        public GetUsuarioByIdQuery(string? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Id = id;
        }
    }
}
