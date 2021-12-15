using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Class model
    /// </summary>
    public class ClassViewModel : ScheduleModel
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
        public List<ClassShiftViewModel> ClassShifts { get; set; } = new List<ClassShiftViewModel>();
    }
}
