using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Room entity
    /// </summary>
    public class Room : Schedule
    {
        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid RoomKey { get; set; }

        /// <summary>
        /// Get or Set Building Key
        /// </summary>
        public Guid BuildingKey { get; set; }

        /// <summary>
        /// Get or Set Building
        /// </summary>
        public Building Building { get; set; }

        /// <summary>
        /// Get or Set Room Name
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Get or Set Normal Capacity
        /// </summary>
        public int NormalCapacity { get; set; }

        /// <summary>
        /// Get or Set Exam Capacity
        /// </summary>
        public int ExamCapacity { get; set; }

        /// <summary>
        /// Get or Set Room Properties
        /// </summary>
        public IEnumerable<RoomProperty> RoomProperties { get; set; }

        /// <summary>
        /// Get or Set Slots
        /// </summary>
        public IEnumerable<Slot> Slots { get; set; }
    }
}
