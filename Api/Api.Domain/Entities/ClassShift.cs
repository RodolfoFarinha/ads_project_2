using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Class shift entity
    /// </summary>
    public class ClassShift : BaseEntity
    {
        /// <summary>
        /// Get or Set Class Shift Key
        /// </summary>
        public Guid ClassShiftKey { get; set; }

        /// <summary>
        /// Get or Set Class Key
        /// </summary>
        public Guid ClassKey { get; set; }

        /// <summary>
        /// Get or Set Class
        /// </summary>
        public Class Class { get; set; }

        /// <summary>
        /// Get or Set Shift Key
        /// </summary>
        public Guid ShiftKey { get; set; }

        /// <summary>
        /// Get or Set Shift
        /// </summary>
        public Shift Shift { get; set; }
    }
}
