using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    public class UnitViewModel : BaseModel
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
        public IEnumerable<CourseUnitViewModel> UnitCourses { get; set; }

        /// <summary>
        /// Get or Set Shifts
        /// </summary>
        public IEnumerable<ShiftViewModel> Shifts { get; set; }
    }
}
