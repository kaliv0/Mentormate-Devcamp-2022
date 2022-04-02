namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models.Orders;

    public interface IOrderService
    {
        Task<ResponseOrderModel> GetOrdersAsync(RequestOrderModel requestOrderModel, string email, string role);

        Task AddOrderAsync(AddOrEditOrderModel orderModel, string email);

        Task EditOrderAsync(int orderId, AddOrEditOrderModel orderModel, string email);

        Task EditOrderCompleteAsync(int orderId);

        Task DeleteOrderAsync(int orderId, string email, string role);

        Task<ViewOrderModel> GetOrderModelByIdAsync(int orderId, string email, string role);
    }
}
