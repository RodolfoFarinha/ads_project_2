using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Slot service
    /// </summary>
    public interface ISlotService
    {
        /// <summary>
        /// Method to get slot by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SlotViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all slots
        /// </summary>
        /// <returns></returns>
        IEnumerable<SlotViewModel> GetAll();

        /// <summary>
        /// Method to save slot
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        SlotViewModel Save(SlotViewModel obj);

        /// <summary>
        /// Method to delete slot
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SlotViewModel Delete(Guid key);
    }
}
