namespace MyWebApi.Business.Services
{
    using MyWebApi.Data.Models.Dtos;
    using MyWebApi.Data.Models.Entities;
    using MyWebApi.Data.Repositories;

    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<List<ToDoItemDTO>> GetAllItemsAsync()
        {
            var items = await _toDoRepository.GetAllItemsAsync();

            var itemsDtos = items
                .OrderByDescending(t => t.PriorityId)
                .ThenByDescending(t => t.StatusId)
                .Select(item => new ToDoItemDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Priority = item.Priority.Title.ToString(),
                    Status = item.Status.Title.ToString(),
                })

             .ToList();

            return itemsDtos;
        }

        public async Task<ToDoItemDTO> GetItemByIdAsync(int id)
        {
            var item = await _toDoRepository.GetItemByIdAsync(id);

            return new ToDoItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Priority = item.Priority.Title.ToString(),
                Status = item.Status.Title.ToString(),
            };
        }

        public async Task<ToDoItemDTO> AddItemAsync(CreateOrUpdateToDoItemDTO item)
        {
            var newItem = new ToDoItem()
            {
                Title = item.Title,
                Description = item.Description,
                PriorityId = (int)item.Priority,
                StatusId = (int)item.Status
            };

            await _toDoRepository.AddItemAsync(newItem);

            return new ToDoItemDTO()
            {
                Id = newItem.Id,
                Title = item.Title,
                Description = item.Description,
                Priority = item.Priority.ToString(),
                Status = item.Status.ToString(),
            };
        }

        public async Task UpdateItemAsync(int id, CreateOrUpdateToDoItemDTO itemDto)
        {
            var itemToUpdate = await _toDoRepository.GetItemByIdAsync(id);

            itemToUpdate.Title = itemDto.Title;
            itemToUpdate.Description = itemDto.Description;
            itemToUpdate.PriorityId = (int)itemDto.Priority;
            itemToUpdate.StatusId = (int)itemDto.Status;

            await _toDoRepository.UpdateItemAsync(id, itemToUpdate);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _toDoRepository.DeleteItemAsync(id);
        }
    }
}
