using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    public class RoomViewModel : BaseModel
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
        public IEnumerable<RoomPropertyViewModel> RoomProperties { get; set; }

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}
