namespace MMRestaurant.Business.Services
{
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models.Orders;
    using MMRestaurant.Domain.Models.Tables;

    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<List<TableModel>> GetTablesAsync()
        {
            var tables = await _tableRepository.GetTablesAsync();

            //process response
            var tableModels = tables.Select(t =>
            {
                var activeOrder = t.Orders.FirstOrDefault(o => o.Status.Title.ToString() == "Active");

                return new TableModel
                {
                    Id = t.Id,
                    Number = t.TableNumber,
                    Capacity = t.Capacity,
                    UserId = activeOrder != null ? activeOrder.UserId : "N/A",
                    UserName = activeOrder != null ? activeOrder.User.Name : "N/A",
                    TotalPrice = activeOrder != null ?
                          activeOrder.OrderProducts.Sum(op => op.Product.Price * op.ProductCount)
                          : 0M,
                    Status = activeOrder != null ? "Active" : "Free"
                };
            }).ToList();

            return tableModels;
        }

        public async Task<ViewTableModel> GetTableModelByIdAsync(int tableId)
        {
            var table = await _tableRepository.GetTableByIdAsync(tableId);

            //process response          
            var activeOrder = table.Orders.FirstOrDefault(o => o.Status.Title.ToString() == "Active");

            var tableModel = new ViewTableModel
            {
                Id = table.Id,
                Number = table.TableNumber,
                Capacity = table.Capacity,
                Status = activeOrder != null ? "Active" : "Free",
                Order = activeOrder != null ? new ViewOrderModel
                {
                    Id = activeOrder.Id,
                    UserId = activeOrder.UserId,
                    UserName = activeOrder.User.Name,
                    Status = activeOrder.Status.Title.ToString(),
                    TotalPrice = activeOrder.OrderProducts
                            .Sum(op => op.Product.Price * op.ProductCount),
                    OrderProducts = activeOrder.OrderProducts
                            .Select(op => new OrderProductModel
                            {
                                Id = op.Product.Id,
                                Name = op.Product.Name,
                                Price = op.Product.Price,
                                Quantity = op.ProductCount
                            })
                            .ToList()
                } : null
            };

            return tableModel;
        }
    }
}
