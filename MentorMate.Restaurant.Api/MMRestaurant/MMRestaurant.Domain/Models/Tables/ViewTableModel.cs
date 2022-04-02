namespace MMRestaurant.Domain.Models.Tables
{
    using MMRestaurant.Domain.Models.Orders;

    public class ViewTableModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Status { get; set; }

        public int Capacity { get; set; }

        public ViewOrderModel? Order { get; set; }
    }
}
