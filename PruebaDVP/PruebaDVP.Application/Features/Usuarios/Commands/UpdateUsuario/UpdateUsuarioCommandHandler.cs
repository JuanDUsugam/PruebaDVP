using AutoMapper;
using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Usuarios;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Usuarios.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Usuario, bool>> expression = u => u.Identificador == request.Id;
            var usuarioSpec = new BaseSpecification<Usuario>(expression);
            var usuarioEntity = await _unitOfWork.Repository<Usuario>().GetByWithSpec(usuarioSpec);

            if (usuarioEntity == null)
            {
                throw new NotFoundException(nameof(usuarioEntity), request.Id);
            }

            _mapper.Map(request, usuarioEntity, typeof(UpdateUsuarioCommand), typeof(Usuario));
            await _unitOfWork.Repository<Usuario>().UpdateAsync(usuarioEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("El registro tipo usuario no se pudo actualizar. ");
            }

            return usuarioEntity.Identificador!;
        }
    }
}
