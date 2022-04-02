namespace MMRestaurant.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Entities.Tables;

    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<Table>> GetTablesAsync()
        {
            //get tables with their dependencies
            var tables = await _dbContext.Tables
                    .Include(t => t.Orders)
                        .ThenInclude(o => o.User)
                    .Include(t => t.Orders)
                        .ThenInclude(o => o.Status)
                    .Include(t => t.Orders)
                        .ThenInclude(o => o.OrderProducts)
                            .ThenInclude(op => op.Product)
                    .ToListAsync();

            if (!tables.Any())
            {
                throw new ArgumentException(TableErrorMessages.NoTablesFound);
            }

            return tables;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            //get requested table with its dependencies
            var table = await _dbContext.Tables
                .Where(t => t.Id == tableId)
                .Include(t => t.Orders)
                    .ThenInclude(o => o.User)
                .Include(t => t.Orders)
                    .ThenInclude(o => o.Status)
                .Include(t => t.Orders)
                    .ThenInclude(o => o.OrderProducts)
                        .ThenInclude(op => op.Product)
                .ToListAsync();


            if (!table.Any())
            {
                throw new ArgumentException(TableErrorMessages.NoTableFound);
            }

            return table[0];
        }
    }
}
