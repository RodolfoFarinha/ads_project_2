using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    public class BuildingViewModel : BaseModel
    {
        /// <summary>
        /// Get or Set Building Key
        /// </summary>
        public Guid BuildingKey { get; set; }

        /// <summary>
        /// Get or Set Building Rooms
        /// </summary>
        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }
}
