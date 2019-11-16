using System;
using System.Collections.Generic;
using System.Text;

namespace STARAAPP.Entities
{
    /// <summary>
    /// User entity class.
    /// </summary>
    public class OrderToUser : OrderToUserBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public OrderToUser()
        {
            //UsersToLocations = new HashSet<UserToLocation>();
            //Activities = new HashSet<Activity>();
            //SensorsToReferencePlantData = new HashSet<SensorToReferencePlantData>();
        }

        /// <summary>
        /// Gets or sets the set of hubs.
        /// </summary>
        /// <value>
        /// The hub to users.
        /// </value>
        //public virtual ICollection<UserToLocation> UsersToLocations { get; set; }
        //public virtual ICollection<Activity> Activities { get; set; }
    }

    /// <summary>
    /// User entity base class.
    /// </summary>
    public class OrderToUserBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public int TimeStart { get; set; }
        public int Status { get; set; }
        public int Duration { get; set; }
    }
}
