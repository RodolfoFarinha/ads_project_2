using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Room property entity
    /// </summary>
    public class RoomProperty : BaseEntity
    {
        /// <summary>
        /// Get or Set Room Property Key
        /// </summary>
        public Guid RoomPropertyKey { get; set; }

        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid RoomKey { get; set; }

        /// <summary>
        /// Get or Set Room
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Property
        /// </summary>
        public Property Property { get; set; }
    }
}
