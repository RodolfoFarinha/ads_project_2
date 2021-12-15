using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Calendar event model
    /// </summary>
    public class CalendarEventViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or Set Number of Sessions Without Room
        /// </summary>
        public int TotalSessionsWithoutRoom { get; set; }

        /// <summary>
        /// Get or Set Start Date
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Get or Set End Date
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Get or Set Color
        /// </summary>
        public EventColor Color { get; set; }

        /// <summary>
        /// Get or Set Sessions Basic Info
        /// </summary>
        public List<SessionBasicInfoViewModel> SessionsBasicInfo { get; set; }


    }
}
