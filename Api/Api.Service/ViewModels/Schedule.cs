using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Schedule model
    /// </summary>
    public class ScheduleModel : BaseModel
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
