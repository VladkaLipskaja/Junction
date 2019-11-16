﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STARAAPP.Entities
{
    /// <summary>
    /// User entity class.
    /// </summary>
    public class User : UserBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
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
    public class UserBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>
        /// The mobile phone.
        /// </value>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }
    }
}