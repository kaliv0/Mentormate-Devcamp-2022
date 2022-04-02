namespace MMRestaurant.Domain.Entities
{
    public class RoleRoleAction
    {
        public string RoleId { get; set; } 

        public virtual Role Role { get; set; }

        public int RoleActionId { get; set; }

        public virtual RoleAction RoleAction { get; set; }
    }
}
