using System;
using System.Collections.Generic;
using System.Text;

namespace STARAAPP.Entities
{
    /// <summary>
    /// Order entity class.
    /// </summary>
    public class Order : OrderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public Order()
        {
            OrdersToUsers = new HashSet<OrderToUser>();
        }

        public virtual ICollection<OrderToUser> OrdersToUsers { get; set; }

        public virtual User User { get; set; }
    }

    /// <summary>
    /// User entity base class.
    /// </summary>
    public class OrderBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int TimeFrom { get; set; }
        public int TimeTo { get; set; }
        public string Measurements { get; set; }
        public string Comments { get; set; }
        public bool IsAssigned { get; set; }
        public decimal? Cost { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string WorkerCommentBefore { get; set; }
        public int WorkerCommentTimeBefore { get; set; }
        public string WorkerPhotoBefore { get; set; }
        public int? CompletionTime { get; set; }
        public string WorkerCommentAfter { get; set; }
        public int WorkerCommentTimeAfter { get; set; }
        public string WorkerPhotoAfter { get; set; }
        public string CustomerComment { get; set; }
        public int CustomerCommentTime { get; set; }
        public string CustomerPhoto { get; set; }
        public int? CustomerMark { get; set; }
        public int ReporterID { get; set; }
    }
}
