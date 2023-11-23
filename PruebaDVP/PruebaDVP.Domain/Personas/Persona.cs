using PruebaDVP.Domain.Common;

namespace PruebaDVP.Domain.Personas
{
    public class Persona : EntityBase<Guid>
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int NumeroDeIdentificacion { get; set; }
        public string Email { get; set; }
        public string? TipoDeIdentificacion { get; set; }

    }
}
