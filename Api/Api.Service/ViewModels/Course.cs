using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Course model
    /// </summary>
    public class CourseViewModel : ScheduleModel
    {
        /// <summary>
        /// Get or Set Course Key
        /// </summary>
        public Guid CourseKey { get; set; }

        /// <summary>
        /// Get or Set Course Name
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Get or Set Course Units
        /// </summary>
        public IEnumerable<CourseUnitViewModel> CourseUnits { get; set; }
    }
}
