namespace MyWebApi.Business.Services
{
    using MyWebApi.Data.Models.Dtos;

    public interface IToDoService
    {
        public IEnumerable<ToDoItemDTO> GetAllItems();

        public ToDoItemDTO GetItemById(Guid id);

        public ToDoItemDTO AddItem(CreateOrUpdateToDoItemDTO item);

        public void UpdateItem(Guid id, CreateOrUpdateToDoItemDTO item);

        public void DeleteItem(Guid id);
    }
}
