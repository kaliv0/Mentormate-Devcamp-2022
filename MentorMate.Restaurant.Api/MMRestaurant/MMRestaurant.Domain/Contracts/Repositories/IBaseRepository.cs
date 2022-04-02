namespace MMRestaurant.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<T> AddAsync(T entity);

        Task EditAsync(T entity);

        Task DeleteAsync(object id);
    }
}
