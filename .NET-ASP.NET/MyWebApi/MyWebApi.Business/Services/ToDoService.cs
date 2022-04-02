namespace MyWebApi.Business.Services
{
    using MyWebApi.Data.Models.Dtos;
    using MyWebApi.Data.Models.Exceptions;
    using MyWebApi.Data.Models.Entities;
    using MyWebApi.Data.Repositories;

    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IEnumerable<ToDoItemDTO> GetAllItems()
        {
            var items = _toDoRepository
                .GetAllItems()
                .Select(item => new ToDoItemDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Priority = item.Priority.ToString(),
                    Status = item.Status.ToString(),
                })
                .ToList();

            return items;
        }

        public ToDoItemDTO GetItemById(Guid id)
        {
            var item = _toDoRepository.GetItemById(id);

            return new ToDoItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Priority = item.Priority.ToString(),
                Status = item.Status.ToString(),
            };
        }

        public ToDoItemDTO AddItem(CreateOrUpdateToDoItemDTO item)
        {
            var newItem = new ToDoItem()
            {
                Id = Guid.NewGuid(),
                Title = item.Title,
                Description = item.Description,
                Priority = item.Priority,
                Status = item.Status
            };

            _toDoRepository.AddItem(newItem);

            return new ToDoItemDTO()
            {
                Id = newItem.Id,
                Title = newItem.Title,
                Description = newItem.Description,
                Priority = newItem.Priority.ToString(),
                Status = newItem.Status.ToString(),
            };
        }

        public void UpdateItem(Guid id, CreateOrUpdateToDoItemDTO item)
        {
            var updatedItem = new ToDoItem()
            {
                Id = id,
                Title = item.Title,
                Description = item.Description,
                Priority = item.Priority,
                Status = item.Status
            };

            _toDoRepository.UpdateItem(id, updatedItem);
        }

        public void DeleteItem(Guid id)
        {
            _toDoRepository.DeleteItem(id);
        }
    }
}
