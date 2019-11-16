using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STARAAPP.Entities
{
    public class OrderToUserMap : IEntityTypeConfiguration<OrderToUser>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<OrderToUser> builder)
        {
            // Primary key
            builder.HasKey(t => new { t.UserID, t.OrderID, t.TimeStart });

            // Properties
            builder.ToTable("orderstousers");

            builder.Property(t => t.UserID).HasColumnName("userid");
            builder.Property(t => t.OrderID).HasColumnName("orderid");
            builder.Property(t => t.TimeStart).HasColumnName("timestart");
            builder.Property(t => t.Status).HasColumnName("status");
            builder.Property(t => t.Duration).HasColumnName("duration");

            //builder.HasOne(t => t.User).WithMany(t => t.HubToUsers).HasForeignKey(t => t.UserID);
        }
    }
}
