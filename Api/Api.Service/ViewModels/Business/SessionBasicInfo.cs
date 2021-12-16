using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Session basic info model
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
        /// Get or Set Shift Name
        /// </summary>
        public string ShiftName { get; set; }

        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid? PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Property Name
        /// </summary>
        public string PropertyName { get; set; }

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
        /// Get or Set Unit Key
        /// </summary>
        public Guid? UnitKey { get; set; }

        /// <summary>
        /// Get or Set Unit Name
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Get or Set Course Key
        /// </summary>
        public Guid? CourseKey { get; set; }

        /// <summary>
        /// Get or Set Course Name
        /// </summary>
        public string CourseName { get; set; }

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
