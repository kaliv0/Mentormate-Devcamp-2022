namespace MMRestaurant.Domain.Models.Tables
{
    public class TableModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Status { get; set; }

        public int Capacity { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
