using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaDVP.Application.Features.Personas.Commands.CreatePerson;
using PruebaDVP.Application.Features.Personas.Commands.DeletePersona;
using PruebaDVP.Application.Features.Personas.Commands.UpdatePersona;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;
using PruebaDVP.Application.Features.Personas.Queries.GetPersonaById;
using System.Net;

namespace PruebaDVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ById/{id}", Name ="GetPersonaById")]
        [ProducesResponseType(typeof(PersonaResponseQuery), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PersonaResponseQuery>> GetPersonaById(string id)
        {
            var personaQuery = new GetPersonaByIdQuery(id);
            return Ok(await _mediator.Send(personaQuery));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreatePersona([FromBody] CreatePersonaCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<string>> UpdatePersona([FromBody] UpdatePersonaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<string>> DeletePersona(string id)
        {
            var command = new DeletePersonaCommand
            {
                Identificador = id,
            };
            return Ok(await _mediator.Send(command));
        }
    }
}
