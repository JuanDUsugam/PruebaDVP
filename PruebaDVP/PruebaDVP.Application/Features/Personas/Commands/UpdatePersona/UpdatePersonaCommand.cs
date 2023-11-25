using MediatR;

namespace PruebaDVP.Application.Features.Personas.Commands.UpdatePersona
{
    public class UpdatePersonaCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public string? TipoIdentificacion { get; set; }
    }
}
