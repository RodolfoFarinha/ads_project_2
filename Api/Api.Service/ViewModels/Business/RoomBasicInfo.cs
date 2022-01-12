using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Room basic info model
    /// </summary>
    public class RoomBasicInfoViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid? RoomKey { get; set; }

        /// <summary>
        /// Get or Set Room Name
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Get or Set Room Capacity
        /// </summary>
        public int? RoomCapacity { get; set; }

        /// <summary>
        /// Get or Set Building Key
        /// </summary>
        public Guid? BuildingKey { get; set; }

        /// <summary>
        /// Get or Set Building Name
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Get or Set Total Hours Allocated
        /// </summary>
        public double TotalHoursAllocated { get; set; }

        /// <summary>
        /// Get or Set Allocation Percentage
        /// </summary>
        public double AllocationPercentage { get; set; }
    }
}
