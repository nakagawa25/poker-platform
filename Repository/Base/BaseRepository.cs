using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PokerPageContext _dataBaseContext;
        public BaseRepository(PokerPageContext context)
        {
            _dataBaseContext = context;
        }

        public virtual IQueryable<T> GetAllQuery()
        {
            return _dataBaseContext.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dataBaseContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dataBaseContext.Set<T>().FindAsync(id);
        }

        public virtual async Task Insert(T entity)
        {
            await _dataBaseContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task Update(T entity)
        {
            _dataBaseContext.Set<T>().Update(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dataBaseContext.Set<T>().Remove(entity);
        }
    }
}
