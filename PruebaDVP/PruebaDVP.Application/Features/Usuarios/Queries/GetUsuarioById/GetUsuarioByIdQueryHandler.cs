using AutoMapper;
using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Usuarios;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioResponseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UsuarioResponseQuery> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Usuario, bool>> expression = u => u.Identificador == request.Id;
            var usuarioSpec = new BaseSpecification<Usuario>(expression);
            var usuarioEntity = await _unitOfWork.Repository<Usuario>().GetByWithSpec(usuarioSpec);

            if (usuarioEntity == null)
            {
                throw new NotFoundException(nameof(usuarioEntity), request.Id!);
            }

            return _mapper.Map<UsuarioResponseQuery>(usuarioEntity);
        }
    }
}
