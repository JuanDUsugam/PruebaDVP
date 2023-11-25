using PruebaDVP.Application.Interfaces.Specifications;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Interfaces.Infrastructure.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task <TEntity> GetByWithSpec(ISpecification<TEntity> spec);
        Task<TEntity> GetByWithSpec(Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, object>>> includes);
    }
}
