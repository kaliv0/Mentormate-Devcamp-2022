namespace MyWebApi.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebApi.Data.Models.Exceptions;
    using MyWebApi.Data.Models.Entities;

    public class ToDoRepository : IToDoRepository
    {
        private readonly MyWebApiDbContext _dbContext;

        public ToDoRepository(MyWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDoItem>> GetAllItemsAsync()
        {
            var items= await _dbContext.ToDoItems
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .ToListAsync();

            if (!items.Any())
            {
                throw new ItemListNotFoundException("No entries found");
            }

            return items;
        }

        public async Task<ToDoItem?> GetItemByIdAsync(int id)
        {
            var item= await _dbContext.ToDoItems
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (item == null)
            {
                throw new ItemNotFoundException("No item found with given Id");
            }

            return item;
        }

        public async Task AddItemAsync(ToDoItem item)
        {
            await _dbContext.ToDoItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int id, ToDoItem item)
        {
            _dbContext.ToDoItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var itemToDelete = await this.GetItemByIdAsync(id);

            if (itemToDelete == null)
            {
                throw new ItemNotFoundException("No item found with given Id");
            }

            _dbContext.ToDoItems.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
