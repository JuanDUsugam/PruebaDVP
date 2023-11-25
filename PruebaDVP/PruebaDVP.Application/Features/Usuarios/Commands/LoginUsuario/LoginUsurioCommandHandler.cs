using MediatR;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;
using PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioByNombreUsuario;
using PruebaDVP.Application.Interfaces.Infrastructure.Identity;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;

namespace PruebaDVP.Application.Features.Usuarios.Commands.LoginUsuario
{
    public class LoginUsurioCommandHandler : IRequestHandler<LoginUsurioCommand, UsuarioLoginResponseDto>
    {
        private readonly IMediator _mediator;
        private readonly IJwtGenerator _jwtGeneretor;

        public LoginUsurioCommandHandler(IMediator mediator, IJwtGenerator jwtGeneretor)
        {
            _mediator = mediator;
            _jwtGeneretor = jwtGeneretor;
        }

        public async Task<UsuarioLoginResponseDto> Handle(LoginUsurioCommand request, CancellationToken cancellationToken)
        {
            var usuarioQuery = new GetUsuarioByNombreUsuarioQuery
            {
                NombreUsuario = request.NombreUsuario
            };
            var usuarioEntity = await _mediator.Send(usuarioQuery);
            if (usuarioEntity.Pass != request.Password)
            {
                throw new Exception("Las credenciales son incorrectas. ");
            }

            var token =  _jwtGeneretor.CreateToken(usuarioEntity);

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
