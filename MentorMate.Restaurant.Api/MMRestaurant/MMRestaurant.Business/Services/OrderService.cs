namespace MMRestaurant.Business.Services
{
    using MMRestaurant.Domain.Constants;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Entities.Orders;
    using MMRestaurant.Domain.Models.Orders;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository,
                            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task AddOrderAsync(AddOrEditOrderModel orderModel, string email)
        {
            if (orderModel.UserId == null)
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                orderModel.UserId = user.Id;
            }

            var userFromRequest = await _userRepository.GetUserByIdAsync(orderModel.UserId);
            if (userFromRequest == null)
            {
                throw new ArgumentException(UserErrorMessages.NoUserFound);
            }

            //create order
            var order = new Order
            {
                StatusId = 1,
                TableId = orderModel.TableId,
                UserId = orderModel.UserId,
                CreatedAt = DateTime.UtcNow,
            };

            var orderInDb = await _orderRepository.AddAsync(order);

            var productsToAdd = new List<OrderProduct>();
            orderModel.Products.ForEach(p =>
            {
                productsToAdd.Add(
                    new OrderProduct
                    {
                        OrderId = orderInDb.Id,
                        ProductId = p.ProductId,
                        ProductCount = p.Quantity
                    });
            });

            await _orderRepository.AddOrderProductsAsync(productsToAdd);
        }

        public async Task DeleteOrderAsync(int orderId, string email, string role)
        {
            if (role != UserRoles.Admin)
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                var userId = user.Id;

                await _orderRepository.DeleteOrderByUserAsync(orderId, userId);
            }
            else
            {
                await _orderRepository.DeleteAsync(orderId);
            }
        }

        public async Task EditOrderAsync(int orderId, AddOrEditOrderModel orderModel, string email)
        {
            if (orderModel.UserId == null)
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                orderModel.UserId = user.Id;
            }

            var userFromRequest = await _userRepository.GetUserByIdAsync(orderModel.UserId);

            if (userFromRequest == null)
            {
                throw new ArgumentException(UserErrorMessages.NoUserFound);
            }

            var orderToUpdate = await _orderRepository.GetOrderWithProducts(orderId);

            //update order
            orderToUpdate.TableId = orderModel.TableId;
            orderToUpdate.UserId = orderModel.UserId;

            await _orderRepository.EditAsync(orderToUpdate);

            //create order products
            var productsToAdd = new List<OrderProduct>();
            orderModel.Products.ForEach(p =>
            {
                productsToAdd.Add(
                    new OrderProduct
                    {
                        OrderId = orderId,
                        ProductId = p.ProductId,
                        ProductCount = p.Quantity
                    });
            });

            await _orderRepository.EditOrderProductsAsync(orderToUpdate, productsToAdd);
        }

        public async Task EditOrderCompleteAsync(int orderId)
        {
            await _orderRepository.EditOrderCompleteAsync(orderId);
        }

        public async Task<ResponseOrderModel> GetOrdersAsync(
            RequestOrderModel requestOrderModel, string email, string role)
        {
            var pageStart = requestOrderModel.Page != null ? (int)requestOrderModel.Page : 1;
            var pageSize = requestOrderModel.PageSize != null ? (int)requestOrderModel.PageSize : 20;

            var ordersInDb = await _orderRepository.GetAllFilteredAsync(requestOrderModel, pageStart, pageSize);

            var orders = ordersInDb.Item1
                .Select(o => new OrderModel
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    UserName = o.User.Name,
                    TableId = o.TableId,
                    TableNumber = o.Table.TableNumber,
                    Status = o.Status.Title.ToString(),
                    TotalPrice = o.OrderProducts
                                .Sum(op => op.Product.Price * op.ProductCount),
                    CreatedAt = o.CreatedAt
                }).ToList();

            //filter by role
            if (role != UserRoles.Admin)
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                orders = orders.Where(o => o.UserName == user.Name).ToList();
            }

            var totalCount = ordersInDb.Item2;

            //create response model list
            var response = new ResponseOrderModel
            {
                Page = pageStart,
                PageSize = pageSize,
                TotalCount = totalCount,
                OrderModels = orders
            };

            return response;
        }

        public async Task<ViewOrderModel> GetOrderModelByIdAsync(int orderId, string email, string role)
        {
            string userId = null;
            if (role != UserRoles.Admin)
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                userId = user.Id;
            }

            var orderInDb = await _orderRepository.GetOrderByIdAsync(orderId, userId);

            var orderModel = new ViewOrderModel
            {
                Id = orderInDb.Id,
                UserId = orderInDb.UserId,
                UserName = orderInDb.User.Name,
                Status = orderInDb.Status.Title.ToString(),
                TotalPrice = orderInDb.OrderProducts
                                .Sum(op => op.Product.Price * op.ProductCount),
                OrderProducts = orderInDb.OrderProducts
                                .Select(op => new OrderProductModel
                                {
                                    Id = op.Product.Id,
                                    Name = op.Product.Name,
                                    Price = op.Product.Price,
                                    Quantity = op.ProductCount
                                })
                                .ToList()
            };

            return orderModel;
        }
    }
}
