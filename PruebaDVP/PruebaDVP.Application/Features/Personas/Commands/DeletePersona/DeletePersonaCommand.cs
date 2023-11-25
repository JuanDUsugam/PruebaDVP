using MediatR;

namespace PruebaDVP.Application.Features.Personas.Commands.DeletePersona
{
    public class DeletePersonaCommand : IRequest<string>
    {
        public string? Identificador { get; set; }
    }
}
