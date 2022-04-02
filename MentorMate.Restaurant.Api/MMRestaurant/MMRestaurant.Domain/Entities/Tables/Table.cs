namespace MMRestaurant.Domain.Entities.Tables
{
    using MMRestaurant.Domain.Entities.Orders;

    public class Table
    {
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public int Capacity { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
