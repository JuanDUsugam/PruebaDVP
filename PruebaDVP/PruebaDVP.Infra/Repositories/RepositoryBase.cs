using Microsoft.EntityFrameworkCore;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Infra.Persistence.SQLSever.Context;

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
            await _appDbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _appDbContext.Set<T>().Remove(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _appDbContext.Set<T>().Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
