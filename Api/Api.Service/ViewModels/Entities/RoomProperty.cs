using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Room property model
    /// </summary>
    public class RoomPropertyViewModel : BaseModel
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
        public RoomViewModel Room { get; set; }

        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Property
        /// </summary>
        public PropertyViewModel Property { get; set; }
    }
}
