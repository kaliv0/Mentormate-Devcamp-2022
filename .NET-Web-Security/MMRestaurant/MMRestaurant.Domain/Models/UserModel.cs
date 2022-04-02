namespace MMRestaurant.Domain.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Actions { get; set; }
    }
}
