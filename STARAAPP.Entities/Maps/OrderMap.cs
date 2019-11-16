using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STARAAPP.Entities
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary key
            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            // Properties
            builder.ToTable("orders");

            builder.Property(t => t.ID).HasColumnName("id");
            builder.Property(t => t.Title).HasColumnName("title");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Photo).HasColumnName("photo");
            builder.Property(t => t.Measurements).HasColumnName("measurements");
            builder.Property(t => t.TimeFrom).HasColumnName("timefrom");
            builder.Property(t => t.TimeTo).HasColumnName("timeto");
            builder.Property(t => t.Comments).HasColumnName("comments");
            builder.Property(t => t.IsAssigned).HasColumnName("isassigned");
            builder.Property(t => t.Cost).HasColumnName("cost");
            builder.Property(t => t.Latitude).HasColumnName("latitude");
            builder.Property(t => t.Longitude).HasColumnName("longitude");
            builder.Property(t => t.WorkerCommentBefore).HasColumnName("workercommentbefore");
            builder.Property(t => t.WorkerCommentTimeBefore).HasColumnName("workercommenttimebefore");
            builder.Property(t => t.WorkerPhotoBefore).HasColumnName("workerphotobefore");
            builder.Property(t => t.CompletionTime).HasColumnName("completiontime");
            builder.Property(t => t.WorkerCommentAfter).HasColumnName("workercommentafter");
            builder.Property(t => t.WorkerCommentTimeAfter).HasColumnName("workercommenttimeafter");
            builder.Property(t => t.WorkerPhotoAfter).HasColumnName("workerphotoafter");
            builder.Property(t => t.CustomerComment).HasColumnName("customercomment");
            builder.Property(t => t.CustomerPhoto).HasColumnName("customerphoto");
            builder.Property(t => t.CustomerMark).HasColumnName("customermark");
            builder.Property(t => t.CustomerCommentTime).HasColumnName("customercommenttime");
            builder.Property(t => t.ReporterID).HasColumnName("reporterid");

            builder.HasOne(t => t.User).WithMany(t => t.Orders).HasForeignKey(t => t.ReporterID);
        }
    }
}
