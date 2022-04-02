namespace MMRestaurant.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string? Picture { get; set; }
    }
}
