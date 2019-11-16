using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STARAAPP.Entities
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            // Properties
            builder.ToTable("users");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Email).HasColumnName("email");
            builder.Property(t => t.MobilePhone).HasColumnName("mobilephone");
            builder.Property(t => t.Password).HasColumnName("password");
            builder.Property(t => t.RoleId).HasColumnName("roleid");

            //builder.HasOne(t => t.User).WithMany(t => t.HubToUsers).HasForeignKey(t => t.UserID);
        }
    }
}
