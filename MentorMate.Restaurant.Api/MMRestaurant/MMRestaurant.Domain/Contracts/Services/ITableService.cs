namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models.Tables;

    public interface ITableService
    {
        Task<List<TableModel>> GetTablesAsync();

        Task<ViewTableModel> GetTableModelByIdAsync(int tableId);
    }
}
