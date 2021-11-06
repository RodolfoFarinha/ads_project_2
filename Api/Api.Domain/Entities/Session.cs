using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    /// <summary>
    /// Session entity
    /// </summary>
    public class Session : ScheduleEntity
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
        /// Get or Set Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Get or Set End Date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Get or Set Time Length
        /// </summary>
        public TimeSpan TimeLength { get => EndDate - StartDate; }

        /// <summary>
        /// Get or Set Time Slot
        /// </summary>
        public TimeSpan TimeSlot
        {
            get
            {
                TimeSpan timeSlot = new TimeSpan();

                foreach (var slot in Slots)
                    timeSlot += slot.EndDate - slot.StartDate;
                
                return timeSlot;
            }
        }

        /// <summary>
        /// Get or Set Session Is Completed
        /// </summary>
        public bool SessionIsCompleted { get => TimeLength == TimeSlot; }

        /// <summary>
        /// Get or Set Slots
        /// </summary>
        public IEnumerable<Slot> Slots { get; set; }  
    }
}
