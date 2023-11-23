namespace PruebaDVP.Application.Interfaces.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Complete();
    }
}
