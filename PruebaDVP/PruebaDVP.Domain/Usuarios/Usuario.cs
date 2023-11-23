using PruebaDVP.Domain.Common;

namespace PruebaDVP.Domain.Usuarios
{
    public class Usuario :EntityBase<Guid>
    {
        public string? User { get; set; }
        public string? Pass { get; set; }
    }
}
