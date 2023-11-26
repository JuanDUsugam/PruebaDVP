using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;
using PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario;
using PruebaDVP.Application.Features.Usuarios.Commands.LoginUsuario;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;
using PruebaDVP.Application.Features.Usuarios.Queries.GetUsuarioById;
using System.Net;

namespace PruebaDVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("UsuarioById/{id}", Name = "GetUsuarioById")]
        [ProducesResponseType(typeof(UsuarioResponseQuery), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UsuarioResponseQuery>> GetUsuarioById(string id)
        {
            var usuarioQuery = new GetUsuarioByIdQuery(id);
            return Ok(await _mediator.Send(usuarioQuery));
        }

        [AllowAnonymous]
        [HttpPost("Login", Name ="Login")]
        [ProducesResponseType(typeof(UsuarioLoginResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UsuarioLoginResponseDto>> Login([FromBody] LoginUsurioCommand command)
        {
            return await _mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("Registrar", Name = "Registrar")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UsuarioLoginResponseDto>> Registrar([FromBody] CreateUsuarioCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
