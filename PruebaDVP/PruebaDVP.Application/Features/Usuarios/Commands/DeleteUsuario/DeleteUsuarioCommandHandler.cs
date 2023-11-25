using AutoMapper;
using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Usuarios;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Usuario, bool>> expression = u => u.Identificador == request.Identificador;
            var usuarioSpec = new BaseSpecification<Usuario>(expression);
            var usuarioEntity = await _unitOfWork.Repository<Usuario>().GetByWithSpec(usuarioSpec);

            if (usuarioEntity == null)
            {
                throw new NotFoundException(nameof(usuarioEntity), request.Identificador);
            }

            await _unitOfWork.Repository<Usuario>().DeleteAsync(usuarioEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("El registro tipo usuario no se pudo borrar.");
            }

            return request.Identificador!;
        }
    }
}
