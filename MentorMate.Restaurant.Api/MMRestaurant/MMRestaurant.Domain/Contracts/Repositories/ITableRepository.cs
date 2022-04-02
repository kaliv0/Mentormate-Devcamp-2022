namespace MMRestaurant.Domain.Contracts.Repositories
{
    using MMRestaurant.Domain.Entities.Tables;

    public interface ITableRepository : IBaseRepository<Table>
    {
        Task<List<Table>> GetTablesAsync();

        Task<Table> GetTableByIdAsync(int tableId);
    }
}
