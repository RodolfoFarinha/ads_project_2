using System;
using System.Collections.Generic;

namespace Api.Service.ViewModels
{
    public class ClassViewModel : BaseModel
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
        public IEnumerable<ClassShiftViewModel> ClassShifts { get; set; }
    }
}
