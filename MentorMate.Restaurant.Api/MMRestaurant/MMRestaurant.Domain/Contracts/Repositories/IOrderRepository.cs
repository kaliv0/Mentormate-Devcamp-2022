namespace MMRestaurant.Domain.Contracts.Repositories
{
    using MMRestaurant.Domain.Entities.Orders;
    using MMRestaurant.Domain.Models.Orders;

    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task AddOrderProductsAsync(List<OrderProduct> products);

        Task DeleteOrderByUserAsync(int orderId, string userId);

        Task EditOrderCompleteAsync(int orderId);

        Task EditOrderProductsAsync(Order orderToUpdate, List<OrderProduct> productsToAdd);

        Task<Order> GetOrderWithProducts(int orderId);

        Task<(List<Order>, int)> GetAllFilteredAsync(
            RequestOrderModel requestOrderModel, int pageStart, int pageSize);

        Task<Order> GetOrderByIdAsync(int orderId, string? userId);
    }
}
