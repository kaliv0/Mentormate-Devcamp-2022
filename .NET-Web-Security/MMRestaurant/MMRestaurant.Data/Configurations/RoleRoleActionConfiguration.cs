namespace MMRestaurant.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Data.Entities;

    public class RoleRoleActionConfiguration : IEntityTypeConfiguration<RoleRoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleRoleAction> builder)
        {
            builder.HasKey(r => new
            {
                r.RoleId,
                r.RoleActionId
            });
        }
    }
}
