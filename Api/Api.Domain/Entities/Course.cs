using Api.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Course entity
    /// </summary>
    public class Course : ScheduleEntity
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
        /// Get or Set Course Type
        /// </summary>
        public CourseEnum CourseType { get; set; }

        /// <summary>
        /// Get or Set Course Units
        /// </summary>
        public IEnumerable<CourseUnit> CourseUnits { get; set; }
    }
}
