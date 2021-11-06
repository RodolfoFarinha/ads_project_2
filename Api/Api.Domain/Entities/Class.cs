using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Class entity
    /// </summary>
    public class Class : ScheduleEntity
    {
        /// <summary>
        /// Get or Set Class Key
        /// </summary>
        public Guid ClassKey { get; set; }

        /// <summary>
        /// Get or Set Class Name
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Get or Set Class Shifts
        /// </summary>
        public IEnumerable<ClassShift> ClassShifts { get; set; }
    }
}
