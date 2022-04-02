namespace MMRestaurant.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using MMRestaurant.Domain.Entities.Orders;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string? Picture { get; set; }

        public virtual List<Order> Orders { get; set; } 
    }
}
