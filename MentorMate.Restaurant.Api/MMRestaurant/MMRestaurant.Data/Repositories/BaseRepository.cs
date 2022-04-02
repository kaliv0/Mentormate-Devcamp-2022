namespace MMRestaurant.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Contracts.Repositories;

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var entityInDb = _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entityInDb.Entity;
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await this.GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("No item found");
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task EditAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
