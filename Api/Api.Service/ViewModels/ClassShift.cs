using System;

namespace Api.Service.ViewModels
{
    public class ClassShiftViewModel : BaseModel
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
        public ClassViewModel Class { get; set; }

        /// <summary>
        /// Get or Set Shift Key
        /// </summary>
        public Guid ShiftKey { get; set; }

        /// <summary>
        /// Get or Set Shift
        /// </summary>
        public ShiftViewModel Shift { get; set; }
    }
}
