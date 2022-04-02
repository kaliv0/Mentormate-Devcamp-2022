namespace MyWebApi.Data.Repositories
{
    using MyWebApi.Data.Models.Exceptions;
    using MyWebApi.Data.Models.Entities;
    using MyWebApi.Data.Models.Entities.Enums;

    public class ToDoRepository : IToDoRepository
    {
        private List<ToDoItem> _toDoItems;

        public ToDoRepository()
        {
            _toDoItems = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                   Id =  Guid.NewGuid(),
                   Title = "DRY",
                   Description = "Don't repeat yourself",
                   Priority = Priority.High,
                   Status= Status.InProgress
                },

                new ToDoItem()
                {
                    Id =  Guid.NewGuid(),
                    Title = "TTCO",
                    Description = "Think twice, code once",
                    Priority = Priority.High,
                    Status = Status.Pending,
                },
            };
        }

        IEnumerable<ToDoItem> IToDoRepository.GetAllItems()
        {
            var items = _toDoItems.ToList();

            if (!items.Any())
            {
                throw new ItemListNotFoundException("No entries found");
            }

            return items;
        }

        ToDoItem IToDoRepository.GetItemById(Guid id)
        {
            var item = _toDoItems.FirstOrDefault(item => item.Id == id);

            if (item == null)
            {
                throw new ItemNotFoundException("No item found with given Id");
            }

            return item;
        }

        void IToDoRepository.AddItem(ToDoItem item)
        {
            _toDoItems.Add(item);
        }

        void IToDoRepository.UpdateItem(Guid id, ToDoItem item)
        {
            var index = _toDoItems.FindIndex(item => item.Id == id);

            if (index > -1)
            {
                _toDoItems[index] = item;
            }
            else
            {
                throw new ItemNotFoundException("No item found with given Id");
            }
        }

        void IToDoRepository.DeleteItem(Guid id)
        {
            var item = _toDoItems.FirstOrDefault(item => item.Id == id);

            if (item == null)
            {
                throw new ItemNotFoundException("No item found with given Id");
            }

            _toDoItems.Remove(item);
        }
    }
}
