using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Building model
    /// </summary>
    public class BuildingViewModel : ScheduleModel
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
        public List<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
    }
}
