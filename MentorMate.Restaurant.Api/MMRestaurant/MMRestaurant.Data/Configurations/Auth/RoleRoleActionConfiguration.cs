namespace MMRestaurant.Data.Configurations.Auth
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Domain.Entities;

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
