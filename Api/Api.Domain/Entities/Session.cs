﻿using System;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Session entity
    /// </summary>
    public class Session : BaseEntity
    {
        /// <summary>
        /// Get or Set Session Key
        /// </summary>
        public Guid SessionKey { get; set; }

        /// <summary>
        /// Get or Set Shift Key
        /// </summary>
        public Guid ShiftKey { get; set; }

        /// <summary>
        /// Get or Set Shift
        /// </summary>
        public Shift Shift { get; set; }

        /// <summary>
        /// Get or Set Property Key
        /// </summary>
        public Guid PropertyKey { get; set; }

        /// <summary>
        /// Get or Set Property
        /// </summary>
        public Property Property { get; set; }

        /// <summary>
        /// Get or Set Room Key
        /// </summary>
        public Guid RoomKey { get; set; }

        /// <summary>
        /// Get or Set Room
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Get or Set Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Get or Set End Date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
