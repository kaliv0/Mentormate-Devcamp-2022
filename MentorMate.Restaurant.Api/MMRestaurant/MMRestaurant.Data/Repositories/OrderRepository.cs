namespace MMRestaurant.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Entities.Orders;
    using MMRestaurant.Domain.Constants.Enums;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Models.Orders;
    using MMRestaurant.Domain.Contracts.Repositories;

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task AddOrderProductsAsync(List<OrderProduct> products)
        {
            await _dbContext.OrderProducts.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderByUserAsync(int orderId, string userId)
        {
            var orderToDelete = await _dbContext.Orders
                .FirstOrDefaultAsync(c => c.Id == orderId);

            if (orderToDelete == null)
            {
                throw new ArgumentException(OrderErrorMessages.NoOrderFound);
            }

            if (orderToDelete.UserId != userId)
            {
                throw new ArgumentException(OrderErrorMessages.NoPermissionToDeleteOrder);
            }

            _dbContext.Orders.Remove(orderToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditOrderProductsAsync(Order orderToUpdate, List<OrderProduct> productsToAdd)
        {
            //remove old products list            
            orderToUpdate.OrderProducts.Clear();
            await _dbContext.SaveChangesAsync();

            //add new products list in order          
            await _dbContext.OrderProducts.AddRangeAsync(productsToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditOrderCompleteAsync(int orderId)
        {
            var orderToEdit = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (orderToEdit == null)
            {
                throw new ArgumentException(OrderErrorMessages.NoOrderFound);
            }

            orderToEdit.StatusId = (int)OrderStatusCode.Complete;

            _dbContext.Orders.Update(orderToEdit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<(List<Order>, int)> GetAllFilteredAsync(
            RequestOrderModel requestOrderModel, int pageStart, int pageSize)
        {
            var orders = _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Table)
                .Include(o => o.Status)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .AsQueryable();

            if (!orders.Any())
            {
                throw new ArgumentException(OrderErrorMessages.NoOrdersFound);
            }

            //filtering orders
            if (requestOrderModel.Status != null)
            {
                var statusId = requestOrderModel.Status == "Active" ? 1 : 2;

                orders = orders.Where(o => o.StatusId == statusId);
            }

            if (requestOrderModel.WaiterName != null)
            {
                orders = orders.Where(o => o.User.Name == (string)requestOrderModel.WaiterName);
            }

            if (requestOrderModel.TableNumber != null)
            {
                orders = orders.Where(o => o.Table.TableNumber == (int)requestOrderModel.TableNumber);
            }

            //sorting products
            if (requestOrderModel.SortBy != null)
            {
                if (requestOrderModel.SortDirection == "desc")
                {
                    if (requestOrderModel.SortBy == "UserName")
                    {
                        orders = orders.OrderByDescending(o => o.User.Name);
                    }
                    else if (requestOrderModel.SortBy == "Table")
                    {
                        orders = orders.OrderByDescending(o => o.Table.TableNumber);
                    }
                    else if (requestOrderModel.SortBy == "Date")
                    {
                        orders = orders.OrderByDescending(o => o.CreatedAt);
                    }
                    else
                    {
                        orders = orders.OrderByDescending(o => o.Id);
                    }
                }
                else
                {
                    if (requestOrderModel.SortBy == "UserName")
                    {
                        orders = orders.OrderBy(o => o.User.Name);
                    }
                    else if (requestOrderModel.SortBy == "Table")
                    {
                        orders = orders.OrderBy(o => o.Table.TableNumber);
                    }
                    else if (requestOrderModel.SortBy == "Date")
                    {
                        orders = orders.OrderBy(o => o.CreatedAt);
                    }
                    else
                    {
                        orders = orders.OrderBy(o => o.Id);
                    }
                }
            }

            var totalCount = await orders.CountAsync();

            //create pagination           
            orders = orders.Skip(pageSize * (pageStart - 1)).Take(pageSize);

            return (await orders.ToListAsync(), totalCount);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId, string? userId)
        {
            var orders = _dbContext.Orders
               .Where(o => o.Id == orderId)
               .Include(o => o.User)
               .Include(o => o.Table)
               .Include(o => o.Status)
               .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
               .AsQueryable();

            if (userId != null)
            {
                orders = orders.Where(o => o.UserId == userId);
            }

            if (!orders.Any())
            {
                throw new ArgumentException(OrderErrorMessages.NoOrderFound);
            }

            return (await orders.ToListAsync())[0];
        }

        public async Task<Order> GetOrderWithProducts(int orderId)
        {
            var orderToUpdate = await _dbContext.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync();

            if (orderToUpdate == null)
            {
                throw new ArgumentException(OrderErrorMessages.NoOrderFound);
            }

            return orderToUpdate;
        }

    }
}
