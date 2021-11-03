using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Unit entity
    /// </summary>
    public class Unit : BaseEntity
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
        public IEnumerable<CourseUnit> UnitCourses { get; set; }

        /// <summary>
        /// Get or Set Shifts
        /// </summary>
        public IEnumerable<Shift> Shifts { get; set; }
    }
}
