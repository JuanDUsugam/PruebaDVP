using MediatR;

namespace PruebaDVP.Application.Features.Personas.Commands.CreatePerson
{
    public class CreatePersonaCommand : IRequest<string>
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public string? TipoIdentificacion { get; set; }
    }
}
