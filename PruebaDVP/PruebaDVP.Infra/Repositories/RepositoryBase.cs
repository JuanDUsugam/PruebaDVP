using Microsoft.EntityFrameworkCore;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Interfaces.Specifications;
using PruebaDVP.Infra.Persistence.SQLSever.Context;
using PruebaDVP.Infra.Specifications;
using System.Linq.Expressions;

namespace PruebaDVP.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _appDbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<T> GetByWithSpec(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (predicate != null) query = query.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _appDbContext.Set<T>().Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_appDbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
