using AutoMapper;
using MediatR;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioEntity = _mapper.Map<Usuario>(request);

            await _unitOfWork.Repository<Usuario>().CreateAsync(usuarioEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("No se puede insertar el registro de tipo Usuario.");
            }

            return usuarioEntity.Identificador!;
        }
    }
}
