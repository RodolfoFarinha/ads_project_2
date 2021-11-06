using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Configuration entity
    /// </summary>
    public class Configuration : BaseEntity
    {
        /// <summary>
        /// Get or Set Configuration Key
        /// </summary>
        public Guid ConfigurationKey { get; set; }

        /// <summary>
        /// Get or Set Configuration Key Dictionary
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Get or Set Configuration Value Dictionary
        /// </summary>
        public string Value { get; set; }
    }
}
