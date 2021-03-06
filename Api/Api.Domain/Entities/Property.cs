using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Property entity
    /// </summary>
    public class Property : BaseEntity
    {
        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Property Name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Get or Set Property Description
        /// </summary>
        public string PropertyDescription { get; set; }

        /// <summary>
        /// Get or Set Property Status
        /// </summary>
        public bool PropertyStatus { get; set; }

        /// <summary>
        /// Get or Set Available Management
        /// </summary>
        public bool AvailableManagement { get; set; }

        /// <summary>
        /// Get or Set Available Request
        /// </summary>
        public bool AvailableRequest { get; set; }

        /// <summary>
        /// Get or Set Property Rooms
        /// </summary>
        public IEnumerable<RoomProperty> PropertyRooms { get; set; }

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public IEnumerable<Session> Sessions { get; set; }
    }
}
