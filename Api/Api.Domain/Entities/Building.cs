using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Building entity
    /// </summary>
    public class Building : ScheduleEntity
    {
        /// <summary>
        /// Get or Set Building Key
        /// </summary>
        public Guid BuildingKey { get; set; }

        /// <summary>
        /// Get or Set Building Name
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Get or Set Building Rooms
        /// </summary>
        public IEnumerable<Room> Rooms { get; set; }
    }
}
