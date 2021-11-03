using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Course entity
    /// </summary>
    public class Course : BaseEntity
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
        public IEnumerable<CourseUnit> CourseUnits { get; set; }
    }
}
