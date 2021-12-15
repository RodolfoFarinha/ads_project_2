using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Quality schedule model
    /// </summary>
    public class QualityScheduleViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Time Execution
        /// </summary>
        public TimeSpan TimeExecution { get; set; }

        /// <summary>
        /// Get or Set Total Rooms Without Session
        /// </summary>
        public int TotalRoomsWithoutSession { get; set; }

        /// <summary>
        /// Get or Set Total Rooms Without Session Masters
        /// </summary>
        public int TotalRoomsWithoutSessionMasters { get; set; }

        /// <summary>
        /// Get or Set Total Rooms Without Session Degrees
        /// </summary>
        public int TotalRoomsWithoutSessionDegrees { get; set; }

        /// <summary>
        /// Get or Set Total Rooms Without Session Work
        /// </summary>
        public int TotalRoomsWithoutSessionWork { get; set; }

        /// <summary>
        /// Get or Set Total Rooms Without Session After Work
        /// </summary>
        public int TotalRoomsWithoutSessionAfterWork{ get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Sessions
        /// </summary>
        public int TotalRoomChangeInSessions { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Sessions Masters
        /// </summary>
        public int TotalRoomChangeInSessionsMasters { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Sessions Degrees
        /// </summary>
        public int TotalRoomChangeInSessionsDegrees { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Sessions Work
        /// </summary>
        public int TotalRoomChangeInSessionsWork { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Sessions After Work
        /// </summary>
        public int TotalRoomChangeInSessionsAfterWork { get; set; }

        /// <summary>
        /// Get or Set Total Room Change Between Sessions
        /// </summary>
        public int TotalRoomChangeBetweenSessions { get; set; }

        /// <summary>
        /// Get or Set Total Room Change Between Sessions Masters
        /// </summary>
        public int TotalRoomChangeBetweenSessionsMasters { get; set; }

        /// <summary>
        /// Get or Set Total Room Change Between Sessions Degrees
        /// </summary>
        public int TotalRoomChangeBetweenSessionsDegrees { get; set; }

        /// <summary>
        /// Get or Set Total Room Change Between Sessions Work
        /// </summary>
        public int TotalRoomChangeBetweenSessionsWork { get; set; }

        /// <summary>
        /// Get or Set Total Room Change Between Sessions After Work
        /// </summary>
        public int TotalRoomChangeBetweenSessionsAfterWork { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Shifts
        /// </summary>
        public int TotalRoomChangeInShifts { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Shifts Masters
        /// </summary>
        public int TotalRoomChangeInShiftsMasters { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Shifts Degrees
        /// </summary>
        public int TotalRoomChangeInShiftsDegrees { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Shifts Work
        /// </summary>
        public int TotalRoomChangeInShiftsWork { get; set; }

        /// <summary>
        /// Get or Set Total Room Change In Shifts After Work
        /// </summary>
        public int TotalRoomChangeInShiftsAfterWork { get; set; }

        /// <summary>
        /// Get or Set Avarage Gap Between Sessions By Shift
        /// </summary>
        public int AvarageGapBetweenSessionsByShift { get; set; }

        /// <summary>
        /// Get or Set Basic Sessions
        /// </summary>
        public List<CalendarEventViewModel> EventsCalendar { get; set; } = new List<CalendarEventViewModel>();
    }
}
