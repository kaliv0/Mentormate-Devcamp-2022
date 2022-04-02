namespace MMRestaurant.Data.Entities
{
    public class RoleAction
    {
        public int Id { get; set; }

        public string ActionType { get; set; }

        public virtual List<RoleRoleAction> RoleRoleActions { get; set; }
    }
}
