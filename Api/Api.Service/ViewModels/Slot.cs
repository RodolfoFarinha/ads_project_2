using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Slot model
    /// </summary>
    public class SlotViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Slot Key
        /// </summary>
        public Guid SlotKey { get; set; }

        /// <summary>
        /// Get or Set Session Key
        /// </summary>
        public Guid SessionKey { get; set; }

        /// <summary>
        /// Get or Set Session
        /// </summary>
        public SessionViewModel Session { get; set; }

        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid RoomKey { get; set; }

        /// <summary>
        /// Get or Set Room
        /// </summary>
        public RoomViewModel Room { get; set; }

        /// <summary>
        /// Get or Set Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Get or Set End Date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
