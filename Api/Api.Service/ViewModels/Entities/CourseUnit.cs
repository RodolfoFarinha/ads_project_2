using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Course Unit model
    /// </summary>
    public class CourseUnitViewModel : BaseModel
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
        public CourseViewModel Course { get; set; }

        /// <summary>
        /// Get or Set Unit Key
        /// </summary>
        public Guid UnitKey { get; set; }

        /// <summary>
        /// Get or Set Unit Id
        /// </summary>
        public UnitViewModel Unit { get; set; }
    }
}
