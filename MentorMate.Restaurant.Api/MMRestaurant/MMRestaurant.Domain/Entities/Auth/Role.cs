namespace MMRestaurant.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class Role : IdentityRole
    {
        public Role(string roleName)
            : base(roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; set; }

        public virtual List<RoleRoleAction> RoleRoleActions { get; set; }
    }
}
