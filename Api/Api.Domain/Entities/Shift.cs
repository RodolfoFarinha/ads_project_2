using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Shift entity
    /// </summary>
    public class Shift : BaseEntity
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
        public Unit Unit { get; set; }

        /// <summary>
        /// Get or Set Enrolled Students
        /// </summary>
        public int EnrolledStudents { get; set; }

        /// <summary>
        /// Get or Set Shift Classes
        /// </summary>
        public IEnumerable<ClassShift> ShiftClasses { get; set; }

        /// <summary>
        /// Get or Set Sessions
        /// </summary>
        public IEnumerable<Session> Sessions { get; set; }
    }
}
