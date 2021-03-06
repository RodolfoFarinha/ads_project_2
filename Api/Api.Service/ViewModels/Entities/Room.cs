using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Room model
    /// </summary>
    public class RoomViewModel : ScheduleModel
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
        public BuildingViewModel Building { get; set; }

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
        public List<RoomPropertyViewModel> RoomProperties { get; set; } = new List<RoomPropertyViewModel>();

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public List<SlotViewModel> Slots { get; set; } = new List<SlotViewModel>();
    }
}
