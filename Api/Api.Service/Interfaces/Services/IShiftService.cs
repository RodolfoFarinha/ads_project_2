using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Shift service
    /// </summary>
    public interface IShiftService
    {
        /// <summary>
        /// Method to get shift by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ShiftViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all shifts
        /// </summary>
        /// <returns></returns>
        IEnumerable<ShiftViewModel> GetAll();

        /// <summary>
        /// Method to save shift
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ShiftViewModel Save(ShiftViewModel obj);

        /// <summary>
        /// Method to delete shift
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ShiftViewModel Delete(Guid key);
    }
}
