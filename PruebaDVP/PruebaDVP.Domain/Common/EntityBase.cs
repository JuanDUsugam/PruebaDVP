namespace PruebaDVP.Domain.Common
{
    public class EntityBase<T>
    {
        public T? Identificador { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
}
