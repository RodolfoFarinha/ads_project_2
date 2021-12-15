using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Unit model
    /// </summary>
    public class UnitViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Unit Key
        /// </summary>
        public Guid UnitKey { get; set; }

        /// <summary>
        /// Get or Set Unit Name
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Get or Set Unit Courses
        /// </summary>
        public List<CourseUnitViewModel> UnitCourses { get; set; } = new List<CourseUnitViewModel>();

        /// <summary>
        /// Get or Set Shifts
        /// </summary>
        public List<ShiftViewModel> Shifts { get; set; } = new List<ShiftViewModel>();
    }
}
