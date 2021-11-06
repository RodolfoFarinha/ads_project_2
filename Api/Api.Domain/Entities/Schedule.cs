using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Schedule entity
    /// </summary>
    public class Schedule : BaseEntity
    {
        /// <summary>
        /// Get or Set Schedule Id
        /// </summary>
        public Guid ScheduleKey { get; set; }

        /// <summary>
        /// Get or Set Schedule Version
        /// </summary>
        public int ScheduleVersion { get; set; }
    }
}
