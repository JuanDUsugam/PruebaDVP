namespace PruebaDVP.Application.Interfaces.Infrastructure.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);

    }
}
