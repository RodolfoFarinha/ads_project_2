using Api.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Shift model
    /// </summary>
    public class ShiftViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Shift Key
        /// </summary>
        public Guid ShiftKey { get; set; }

        /// <summary>
        /// Get or Set Unit Key
        /// </summary>
        public Guid UnitKey { get; set; }

        /// <summary>
        /// Get or Set Unit
        /// </summary>
        public UnitViewModel Unit { get; set; }

        /// <summary>
        /// Get or Set Shift Name
        /// </summary>
        public string ShiftName { get; set; }

        /// <summary>
        /// Get or Set Shift Type
        /// </summary>
        public ShiftEnum ShiftType { get; set; }

        /// <summary>
        /// Get or Set Enrolled Students
        /// </summary>
        public int EnrolledStudents { get; set; }

        /// <summary>
        /// Get or Set Shift Classes
        /// </summary>
        public List<ClassShiftViewModel> ShiftClasses { get; set; } = new List<ClassShiftViewModel>();

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public List<SessionViewModel> Sessions { get; set; } = new List<SessionViewModel>();
    }
}
