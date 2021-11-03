using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    public class ShiftViewModel : BaseModel
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
        /// Get or Set Enrolled Students
        /// </summary>
        public int EnrolledStudents { get; set; }

        /// <summary>
        /// Get or Set Shift Classes
        /// </summary>
        public IEnumerable<ClassShiftViewModel> ShiftClasses { get; set; }

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}
