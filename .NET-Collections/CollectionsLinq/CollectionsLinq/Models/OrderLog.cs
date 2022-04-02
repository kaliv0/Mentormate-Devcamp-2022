namespace CollectionsLinq.Models
{
    public class OrderLog
    {
        public OrderLog(int orderNumber, DateTime date, ICollection<ProductOrder> productOrder)
        {
            this.OrderNumber = orderNumber;
            this.Date = date;
            this.ProductOrders = productOrder;
        }
        public int OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }

        public decimal TotalPrice => ProductOrders.Sum(p => p.TotalPrice);
    }
}
