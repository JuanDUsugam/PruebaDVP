using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Usuarios;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioByNombreUsuario
{
    public class GetUsuarioByNombreUsuarioQueryHandler : IRequestHandler<GetUsuarioByNombreUsuarioQuery, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsuarioByNombreUsuarioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Handle(GetUsuarioByNombreUsuarioQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Usuario, bool>> expression = u => u.NombreUsuario == request.NombreUsuario;
            var usuarioSpec = new BaseSpecification<Usuario>(expression);
            var usuarioEntity = await _unitOfWork.Repository<Usuario>().GetByWithSpec(usuarioSpec);
            if (usuarioEntity == null)
            {
                throw new NotFoundException(nameof(usuarioEntity), request.NombreUsuario!);
            }

            return usuarioEntity;
        }
    }
}
