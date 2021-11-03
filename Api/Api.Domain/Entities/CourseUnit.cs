using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Course unit entity
    /// </summary>
    public class CourseUnit : BaseEntity
    {
        /// <summary>
        /// Get or Set Course Unit Key
        /// </summary>
        public Guid CourseUnitKey { get; set; }

        /// <summary>
        /// Get or Set Course Key
        /// </summary>
        public Guid CourseKey { get; set; }

        /// <summary>
        /// Get or Set Course
        /// </summary>
        public Course Course { get; set; }

        /// <summary>
        /// Get or Set Unit Key
        /// </summary>
        public Guid UnitKey { get; set; }

        /// <summary>
        /// Get or Set Unit Id
        /// </summary>
        public Unit Unit { get; set; }
    }
}
