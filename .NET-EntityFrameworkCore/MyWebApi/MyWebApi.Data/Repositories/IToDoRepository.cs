namespace MyWebApi.Data.Repositories
{
    using MyWebApi.Data.Models.Entities;

    public interface IToDoRepository
    {
        Task<ToDoItem?> GetItemByIdAsync(int id);

        Task<List<ToDoItem>> GetAllItemsAsync();

        Task AddItemAsync(ToDoItem item);

        Task UpdateItemAsync(int id, ToDoItem item);

        Task DeleteItemAsync(int id);
    }
}
