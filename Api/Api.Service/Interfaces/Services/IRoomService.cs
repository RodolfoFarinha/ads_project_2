using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Room service
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Method to get room by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        RoomViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all rooms
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoomViewModel> GetAll();

        /// <summary>
        /// Method to save room
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        RoomViewModel Save(RoomViewModel obj);

        /// <summary>
        /// Method to delete room
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        RoomViewModel Delete(Guid key);
    }
}
