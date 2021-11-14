using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Session model
    /// </summary>
    public class SessionBasicInfoViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Session Key
        /// </summary>
        public Guid SessionKey { get; set; }

        /// <summary>
        /// Get or Set Shift Key
        /// </summary>
        public Guid ShiftKey { get; set; }

        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Building Key
        /// </summary>
        public Guid? BuildingKey { get; set; }

        /// <summary>
        /// Get or Set Building Name
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid? RoomKey { get; set; }

        /// <summary>
        /// Get or Set Room Name
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Get or Set Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or Set Start Date
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Get or Set End Date
        /// </summary>
        public DateTime End { get; set; }
    }
}
