using PruebaDVP.Domain.Common;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Domain.Personas
{
    public class Persona : EntityBase<string>
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public string? TipoIdentificacion { get; set; }
        public string? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
