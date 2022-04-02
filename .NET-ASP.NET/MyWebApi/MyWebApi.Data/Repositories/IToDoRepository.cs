namespace MyWebApi.Data.Repositories
{
    using MyWebApi.Data.Models.Entities;

    public interface IToDoRepository
    {
        ToDoItem GetItemById(Guid id);

        IEnumerable<ToDoItem> GetAllItems();

        void AddItem(ToDoItem item);

        void UpdateItem(Guid id, ToDoItem item);

        void DeleteItem(Guid id);
    }
}
