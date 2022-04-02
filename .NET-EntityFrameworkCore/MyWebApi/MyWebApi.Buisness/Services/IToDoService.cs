namespace MyWebApi.Business.Services
{
    using MyWebApi.Data.Models.Dtos;

    public interface IToDoService
    {
        Task<List<ToDoItemDTO>> GetAllItemsAsync();

        Task<ToDoItemDTO> GetItemByIdAsync(int id);

        Task<ToDoItemDTO> AddItemAsync(CreateOrUpdateToDoItemDTO item);

        Task UpdateItemAsync(int id, CreateOrUpdateToDoItemDTO item);

        Task DeleteItemAsync(int id);
    }
}
