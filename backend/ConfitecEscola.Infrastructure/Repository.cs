using ConfitecEscola.Core.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ConfitecEscola.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ConfitecEscolaContext _userContext;

        public Repository(ConfitecEscolaContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _userContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _userContext.Set<T>().AddAsync(entity);
            await _userContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _userContext.Set<T>().Remove(entity);
            await _userContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _userContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _userContext.Set<T>().Update(entity);
            await _userContext.SaveChangesAsync();
        }
    }
}
