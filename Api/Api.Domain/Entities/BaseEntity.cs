using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Base entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Get or Set Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or Set Create By User
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// Get or Set Create Date
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Get or Set Modify By User
        /// </summary>
        public string ModifyUser { get; set; }

        /// <summary>
        /// Get or Set Modify Date
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// Get or Set Deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Get or Set Deleted By User
        /// </summary>
        public string DeleteUser { get; set; }

        /// <summary>
        /// Get or Set Deleted Date
        /// </summary>
        public DateTime? DeleteDate { get; set; }
    }
}
