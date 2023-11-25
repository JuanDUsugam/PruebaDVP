using PruebaDVP.Domain.Common;
using PruebaDVP.Domain.Personas;

namespace PruebaDVP.Domain.Usuarios
{
    public class Usuario :EntityBase<string>
    {
        public string? NombreUsuario { get; set; }
        public string? Pass { get; set; }
    }
}
