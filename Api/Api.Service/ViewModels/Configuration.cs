using System;

namespace Api.Service.ViewModels
{
    /// <summary>
    /// Configuration entity
    /// </summary>
    public class ConfigurationViewModel : BaseModel
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
