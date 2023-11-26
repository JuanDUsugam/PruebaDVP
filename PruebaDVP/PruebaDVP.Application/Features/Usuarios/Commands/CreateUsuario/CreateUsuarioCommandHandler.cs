using AutoMapper;
using MediatR;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;
using PruebaDVP.Application.Interfaces.Infrastructure.Identity;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, UsuarioLoginResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtGenerator _jwtGeneretor;

        public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtGeneretor = jwtGenerator;
        }

        public async Task<UsuarioLoginResponseDto> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioEntity = _mapper.Map<Usuario>(request);
            usuarioEntity.Identificador = Guid.NewGuid().ToString();
            await _unitOfWork.Repository<Usuario>().CreateAsync(usuarioEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("No se puede insertar el registro de tipo Usuario.");
            }

            var token = _jwtGeneretor.CreateToken(usuarioEntity);

            var loginResponse = new UsuarioLoginResponseDto
            {
                Id = usuarioEntity.Identificador,
                NombreUsuario = usuarioEntity.NombreUsuario,
                Token = token
            };

            return loginResponse;
        }
    }
}
